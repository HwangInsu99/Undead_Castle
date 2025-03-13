using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public float health;
    public float maxHealth;
    Skill skill;
    float timer;

    public Transform target;
    public NavMeshAgent navAgent;
    public Animator anim;
    Player player;
    Spawner spawner;
    public int attack;
    public int[] attackHp;
    public int summon;

    public void Awake()
    {
        target = GameObject.Find("BossStand").GetComponent<Transform>();
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        skill = GameObject.Find("Skill").GetComponent<Skill>();
        navAgent.SetDestination(target.position);
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }
    private void OnEnable()
    {
        health = maxHealth;
    }
    private void Update()
    {
        //시간이 지날때마다 체력이 줄고 일정체력마다 몬스터소환및 직접공격
        timer += Time.deltaTime;
        if (timer > 0.2f && health > 0)
        {
            Damage(8);
            timer = 0;
        }
        if (health <= summon * 100 && health != 0)
        {
            summon -= 1;
            StartCoroutine(BossSkill());
        }
        //체력 설정은 유니티 프리펩(3000,2000,1000,300)
        if(health <= attackHp[attack])
        {
            attack += 1;
            StartCoroutine(BossAttack());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BossStand")
        {
            navAgent.isStopped = true;
            navAgent.velocity = Vector3.zero;
        }
        else if (other.CompareTag("Typhoon"))
            Damage(skill.TyphoonDamage);
        else if (other.CompareTag("RTyphoon"))
            Damage(skill.RTyphoonDamage);
        else if (!skill.mMUp && (other.CompareTag("MagicMissile") || other.CompareTag("Explode")))
        {
            Damage(skill.MagicDamage);
            if (other.CompareTag("MagicMissile"))
            {
                Destroy(other.gameObject, 0.4f);
            }
        }
        else if (!skill.mMUp && (other.CompareTag("RMagicMissile") || other.CompareTag("ExplodeR")))
        {
            Damage(skill.RMagicDamage);
            if (other.CompareTag("RMagicMissile"))
            {
                Destroy(other.gameObject, 0.4f);
            }
        }
        else if (skill.mMUp && other.CompareTag("MagicMissile"))
        {
            Damage(skill.MagicDamage);
            Destroy(other.gameObject, 2.4f);
        }
        else if (skill.mMUp && other.CompareTag("Explode"))
            Damage(skill.MagicDamage * 5);
        else if (skill.mMUp && other.CompareTag("RMagicMissile"))
        {
            Damage(skill.RMagicDamage);
            Destroy(other.gameObject, 2.4f);
        }
        else if (skill.mMUp && other.CompareTag("ExplodeR"))
            Damage(skill.RMagicDamage * 5);
        else if (other.CompareTag("SHSuicide"))
            Damage(30);
    }


    public void Damage(float x)
    {
        health -= x;
        if (health <= 0)
        {
            health = 0;
            gameObject.layer = 9;
            MonsterDie();
        }
    }
    IEnumerator BossAttack()
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.6f);
        player.PlayerDamaged(attack);
        yield return new WaitForSeconds(1.4f);
        StopCoroutine(BossAttack());
    }
    IEnumerator BossSkill()
    {
        anim.SetTrigger("Magic");
        yield return new WaitForSeconds(1);
        spawner.BossSkill();
        yield return new WaitForSeconds(0.8f);
        StopCoroutine(BossSkill());
    }
    public void MonsterDie()
    {
        player.PlayerKilled();
        anim.SetTrigger("Die");
        StopCoroutine(BossAttack());
        StopCoroutine(BossSkill());
        StartCoroutine(Wait());
        Destroy(gameObject, 3.2f);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        player.Clear();
    }
}
