using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent navAgent;
    public int road;
    public Animator anim;
    public bool stun;
    public bool isRun;
    public float ASpeed;
    public int MDamage;
    Player player;
    Skill skill;

    public void Awake()
    {
        stun = false;
        isRun = true;
        road = Random.Range(0, 6);

        if (road > 2)
            road = 0;
        //소환 시 이동 경로
        if (road == 0)
        {
            target = GameObject.Find("PlayerB").GetComponent<Transform>();
        }
        else if (road == 1)
        {
            target = GameObject.Find("TurnL").GetComponent<Transform>();
        }
        else if (road == 2)
        {
            target = GameObject.Find("TurnR").GetComponent<Transform>();
        }
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        skill = GameObject.Find("Skill").GetComponent<Skill>();
        navAgent.SetDestination(target.position);
    }

    void OnTriggerEnter(Collider coll)
    {
        //방향전환 또는 플레이어에게 닿을시
        if (coll.gameObject.tag == "Player")
        {
            isRun = false;
            navAgent.isStopped = true;
            navAgent.velocity = Vector3.zero;
            StartCoroutine(Attack());
        }
        else if (coll.gameObject.tag == "Turn")
        {
            if (road == 1)
            {
                target = GameObject.Find("PlayerL").GetComponent<Transform>();
                navAgent.SetDestination(target.position);
            }
            else if (road == 2)
            {
                target = GameObject.Find("PlayerR").GetComponent<Transform>();
                navAgent.SetDestination(target.position);
            }
        }
        //밀치기에 맞았을 시
        else if (coll.gameObject.name == "KnockPos" && stun == true)
        {
            StopCoroutine(Attack());
            isRun = true;
            anim.speed = 0;
            if(skill.knockUp)
                StartCoroutine(Pushing(0.6f));
            else
                StartCoroutine(Pushing(0.3f));

        }
    }
    //밀치기외의 기절 - 지속시간은 x
    public IEnumerator Stun(float x)
    {
        if (!isRun)
            StopCoroutine(Attack());
        else
        {
            navAgent.isStopped = true;
            navAgent.velocity = Vector3.zero;
        }
        anim.speed = 0;
        yield return new WaitForSeconds(x);
        anim.speed = 1;
        if (!isRun)
            StartCoroutine(Attack());
        else
            navAgent.isStopped = false;
    }
    //밀치기에 맞은 적을 다시 행동시킴
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
    IEnumerator Attack()
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.6f);
        player.PlayerDamaged(MDamage);
        yield return new WaitForSeconds(ASpeed - 0.6f);
        if (!isRun)
        {
            reAttack();
        }
    }
    public void reAttack()
    {
        StopCoroutine(Attack());
        StartCoroutine(Attack());
    }
    public void MonsterDie()
    {
        player.PlayerKilled();
        navAgent.isStopped = true;
        navAgent.velocity = Vector3.zero;
        anim.SetTrigger("Die");
        StopCoroutine(Attack());
        Destroy(gameObject, 0.9f);
    }
}
