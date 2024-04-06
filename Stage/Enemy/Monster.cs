using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float health;
    public float maxHealth;
    Skill skill;
    Enemy enemy;
    Vector3 Knock;

    void Start()
    {
        skill = GameObject.Find("Skill").GetComponent<Skill>();
        enemy = GetComponent<Enemy>();
        Knock = GameObject.Find("KnockPos").transform.position;
    }
    void Update()
    {
        if (enemy.stun)
        {
            Vector3 velo = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, Knock, ref velo, 0.03f);
        }
    }
    private void OnEnable()
    {
        health = maxHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        //공격을 받았을 시의 데미지 판정 및 파괴되는 플레이어의 스킬처리
        if (other.CompareTag("CAttack"))
        {
            if (skill.Reinforce >= 1)
            {
                Damage(skill.StompDamage * 2);
            }
            else
            {
                Damage(skill.StompDamage);
            }
        }
        else if (other == skill.SlashPos)
        {
            if (skill.slashUp)
            {
                StartCoroutine(enemy.Stun(0.5f));
            }
            if (skill.Reinforce >= 1)
            {
                Damage(skill.SlashDamage * 2);
            }
            else
            {
                Damage(skill.SlashDamage);
            }
        }
        else if (other == skill.DoubleSPos)
        {
            if (skill.dSlashUp)
                StartCoroutine(enemy.Stun(0.4f));
            if (skill.Reinforce >= 2)
                Damage(skill.DoubleSlashDamage * 2);
            else
                Damage(skill.DoubleSlashDamage);
        }
        else if (other == skill.KnockBackPos)
        {
            enemy.stun = true;
            enemy.navAgent.isStopped = true;
            enemy.navAgent.velocity = Vector3.zero;
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
                Destroy(other.gameObject, 0.4f);
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
        //자폭병의 자폭데미지 코드를 실수로 Explode로 이름지어놓고 바꾸지않았음
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
            enemy.MonsterDie();
        }
    }
}
