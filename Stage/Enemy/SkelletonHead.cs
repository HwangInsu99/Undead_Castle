using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkelletonHead : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent navAgent;
    public Animator anim;
    public bool stun;
    public bool isRun;
    public float ASpeed;
    public int MDamage;
    Player player;
    Skill skill;
    Vector3 Knock;
    public float health;
    public float maxHealth;

    public SphereCollider SH;
    //자폭병이며 중앙길로만 가고 플레이어와 닿거나 죽을 시 자폭하면서 주변에 데미지를 주기에 Enemy와 코드가 달라 분리했으나 유사함
    public void Awake()
    {
        stun = false;
        isRun = true;
        target = GameObject.Find("PlayerB").GetComponent<Transform>();
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        SH = GetComponentInChildren<SphereCollider>();
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        skill = GameObject.Find("Skill").GetComponent<Skill>();
        navAgent.SetDestination(target.position);
        Knock = GameObject.Find("KnockPos").transform.position;
    }
    void Update()
    {
        if (stun)
        {
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, Knock, ref velo, 0.03f);
        }
    }
    private void OnEnable()
    {
        health = maxHealth;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "KnockPos" && stun == true)
        {
            isRun = true;
            anim.speed = 0;
            if (skill.knockUp)
                StartCoroutine(Pushing(0.6f));
            else
                StartCoroutine(Pushing(0.3f));

        }
        //플레이어혹은 스킬의 어떤것과 닿아도 폭발(몬스터끼리는 충돌판정없음)
        else if (!coll.CompareTag("Turn") && coll.gameObject.name != "KnockPos")
        {
            isRun = false;
            navAgent.isStopped = true;
            navAgent.velocity = Vector3.zero;
            Damage(1);
        }
    }
    public IEnumerator Stun(float x)
    {
        navAgent.isStopped = true;
        navAgent.velocity = Vector3.zero;
        anim.speed = 0;
        yield return new WaitForSeconds(x);
        anim.speed = 1;
        navAgent.isStopped = false;
    }
    IEnumerator Pushing(float x)
    {
        yield return new WaitForSeconds(x);
        stun = false;
        anim.speed = 1;
        anim.SetTrigger("Run");
        target = GameObject.Find("PlayerB").GetComponent<Transform>();
        navAgent.SetDestination(target.position);
        if (skill.knockUp)
            navAgent.speed *= 0.5f;
        navAgent.isStopped = false;
        StopCoroutine(Pushing(0));
    }
    public void Damage(float x)
    {
        health -= x;
        if (health <= 0)
        {
            gameObject.layer = 12;
            StartCoroutine(Exploded());
        }
    }
    //자폭
    IEnumerator Exploded()
    {
        player.PlayerKilled();
        navAgent.isStopped = true;
        navAgent.velocity = Vector3.zero;
        anim.SetTrigger("Die");
        SH.enabled = true;
        yield return new WaitForSeconds(0.3f);
        gameObject.layer = 9;
        SH.enabled = false;
        Destroy(gameObject, 0.6f);
    }
}
