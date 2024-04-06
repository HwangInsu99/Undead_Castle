using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public float HP;
    public float MHP;
    public float basePower;
    public float Power;
    public int stack;
    public int ExtraLife = 0;
    public bool killUp;
    public int Exp;
    public int Request;
    public int Level;
    public bool Untouchable;
    public bool levelUp;

    public GameManager GameManager;

    public HPBar healthBar;
    public ExpBar expBar;
    public RectTransform dieRect;
    public RectTransform clearRect;

    ESword eSword;
    Animator anim;
    SoundOptions soundOptions;

    void Awake()
    {
        if (GameObject.Find("SoundManager") != null)
        {
            soundOptions = GameObject.Find("SoundManager").GetComponent<SoundOptions>();
        }
        eSword = GetComponent<ESword>();
        HP = MHP;
        anim = GetComponent<Animator>();
        Power = basePower;
        expBar.SetMaxEXP(Request);
    }

    void Start()
    {
        expBar.SetMinEXP(Exp);
        healthBar.SetMaxHealth(MHP);       
    }
    public void PlayerAction(int x)
    {
        switch (x)
        {
            case 0:
                eSword.ESwords(0);
                anim.SetTrigger("Slash");
                break;
            case 1:
                eSword.ESwords(1);
                anim.SetTrigger("Stomp");
                break;
            case 2:
                anim.SetTrigger("Knock");
                break;
            case 3:
                anim.SetTrigger("Magic");
                break;
            case 4:
                eSword.ESwords(2);
                anim.SetTrigger("DSlash");
                break;
            case 5:
                anim.SetTrigger("Slash");
                break;
        }
    }
    public void PlayerKilled()
    {
        Exp += 1;
        expBar.SetEXP(Exp);

        if (killUp && stack <= 4)
        {
            stack++;
            Power = basePower * (1 + stack * 0.1f);
        }
        if (Exp >= Request && Level <=10)
        {      
            PlayerLevelUp();
        }
    }
    public void PlayerLevelUp()
    {
        Level++;
        levelUp = true;
        SfxManager.instance.PlaySfx(SfxManager.Sfx.LevelUp);
        Exp = 0;
        expBar.SetMinEXP(Exp);
        GameManager.Levelup();
    }
    public void PlayerDamaged(float x)
    {
        if (!Untouchable)
        {
            HP -= x;
            SfxManager.instance.PlaySfx(SfxManager.Sfx.Matk);
            healthBar.SetHealth(HP);
        }
           
        if (ExtraLife > 0 && HP <= 0)
        {
            Untouchable = true;
            GameManager.instance.skill.ActiveSkill(2);
            HP = MHP;
            healthBar.SetHealth(HP);
            ExtraLife -= 1;
            StartCoroutine(Invincibility());
        }
        if (ExtraLife == 0 && HP <= 0)
            PlayerDie();
    }
    IEnumerator Invincibility()
    {
        yield return new WaitForSeconds(5);
        Untouchable = false;
        StopCoroutine(Invincibility());
    }
    public void PlayerDie()
    {
        if (GameObject.Find("SoundManager") != null)
        {
            soundOptions.delete();
        }
        Time.timeScale = 0.0f;
        dieRect.localScale = Vector3.one;
    }
    public void Clear()
    {
        if (GameObject.Find("SoundManager") != null)
        {
            soundOptions.delete();
        }
        Time.timeScale = 0.0f;
        clearRect.localScale = Vector3.one;
    }
}

