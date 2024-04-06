using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public int up = 1;
    public int Reinforce = 0; //분노 발동시 1, 분노강화 후 발동시 2
    public int did;
    public float TyphoonDamage;
    public float MagicDamage;
    public float RTyphoonDamage;
    public float RMagicDamage;
    public float SlashDamage;
    public float StompDamage;
    public float DoubleSlashDamage;
    public SphereCollider SlashPos;
    public SphereCollider DoubleSPos;
    public SphereCollider KnockBackPos;
    public BoxCollider StompPos;
    Range range;
    Effect effect;
    Player player;
    public HPBar healthBar;

    public int magicUp;
    public bool knockUp;
    public bool slashUp;
    public bool stompUp;
    public bool dSlashUp;
    public bool mMUp;
    public bool hUp;
    public bool ultUp;

    public GameObject[] explode;
    public Transform explodeT;
    Vector3 et;



    private void Start()
    {
        range = GetComponent<Range>();
        effect = GetComponent<Effect>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    //업그레이드와 분노상태의 유무를 체크하여 스킬사용
    public void ActiveSkill(int x)
    {
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Use);
        if (hUp)
        {
            player.HP += 5;
            healthBar.SetHealth(player.HP);
            if (player.HP > player.MHP)
                player.HP = player.MHP;
        }
        switch (x)
        {
            case 0:
                if (slashUp)
                    SlashDamage = (player.Power * 0.5f) * 1.5f;
                else
                    SlashDamage = player.Power * 0.5f;
                StartCoroutine(Attack(0));
                break;
            case 1:
                if (stompUp)
                    StompDamage = (player.Power * 1) * 2;
                else
                    StompDamage = player.Power * 1;
                StartCoroutine(Attack(1));
                break;
            case 2:
                StartCoroutine(Attack(2));
                break;
            case 3:
                if (Reinforce >= 1)
                {
                    RMagicDamage = player.Power * 2.4f;
                    StartCoroutine(Attack(6));
                    Reinforce = 0;
                }
                else
                {
                    MagicDamage = player.Power * 1.2f;
                    StartCoroutine(Attack(4));
                }
                break;
            case 4:
                Buff(1);
                break;
            case 5:
                Buff(2);
                break;
            case 6:
                DoubleSlashDamage = player.Power * 0.8f;
                StartCoroutine(Attack(3));
                break;
            case 7:
                if (Reinforce >= 2)
                {
                    RTyphoonDamage = player.Power * 4.4f;
                    StartCoroutine(Attack(7));
                    Reinforce = 0;
                }
                else
                {
                    TyphoonDamage = player.Power * 2.2f;
                    StartCoroutine(Attack(5));
                }
                break;
        }
    }
    IEnumerator Attack(int x)
    {
        yield return null;
        switch (x)
        {
            case 0:
                player.PlayerAction(0);
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Slash);
                SlashPos.enabled = true;
                yield return new WaitForSeconds(0.1f);
                SlashPos.enabled = false;
                Reinforce = 0;
                break;
            case 1:
                player.PlayerAction(1);
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Smite);
                yield return new WaitForSeconds(0.1f);
                StompPos.enabled = true;
                yield return new WaitForSeconds(0.1f);
                StompPos.enabled = false;
                Reinforce = 0;
                break;
            case 2:
                player.PlayerAction(2);
                KnockBackPos.enabled = true;
                yield return new WaitForSeconds(0.1f);
                effect.Effects(2);
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Knock);
                KnockBackPos.enabled = false;
                break;
            case 3:
                player.PlayerAction(4);
                DoubleSPos.enabled = true;
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Sp);
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Slash);
                yield return new WaitForSeconds(0.08f);
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Sp);
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Slash);
                DoubleSPos.enabled = false;
                yield return new WaitForSeconds(0.37f);
                DoubleSPos.enabled = true;
                yield return new WaitForSeconds(0.1f);
                DoubleSPos.enabled = false;
                if (dSlashUp)
                {
                    SfxManager.instance.PlaySfx(SfxManager.Sfx.Sp);
                    SfxManager.instance.PlaySfx(SfxManager.Sfx.Slash);
                    yield return new WaitForSeconds(0.03f);
                    player.PlayerAction(0);
                    DoubleSPos.enabled = true;
                    yield return new WaitForSeconds(0.08f);
                    DoubleSPos.enabled = false;
                }
                if (ultUp)
                {
                    did++;
                    if (did >= 2)
                    {
                        did = 0;
                        break;
                    }
                    yield return new WaitForSeconds(0.08f);
                    StartCoroutine(Attack(3));
                }
                if (Reinforce >= 2)
                    Reinforce = 0;
                break;
            case 4:
                player.PlayerAction(3);
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Magic);
                range.Fire(0 + magicUp);
                break;
            case 5:
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Sp);
                player.PlayerAction(5);
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Cyc);
                range.Fire(1 + magicUp);
                if (ultUp)
                {
                    did++;
                    if (did >= 2)
                    {
                        did = 0;
                        break;
                    }
                    yield return new WaitForSeconds(0.2f);
                    StartCoroutine(Attack(5));
                }
                break;
            case 6:
                player.PlayerAction(3);
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Magic);
                range.Fire(2 + magicUp);
                break;
            case 7:
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Sp);
                player.PlayerAction(5);
                SfxManager.instance.PlaySfx(SfxManager.Sfx.Cyc);
                range.Fire(3 + magicUp);
                if (ultUp)
                {
                    did++;
                    if (did >= 2)
                    {
                        did = 0;
                        break;
                    }
                    yield return new WaitForSeconds(0.2f);
                    StartCoroutine(Attack(7));
                }
                break;

        }
    }
    public void Buff(int x)
    {
        if (x == 1)
        {
            player.HP += 20;
            SfxManager.instance.PlaySfx(SfxManager.Sfx.Potion);
            effect.Effects(0);
            if (player.HP > player.MHP)
                player.HP = player.MHP;
            healthBar.SetHealth(player.HP);
        }
        else if (x == 2)
        {
            Reinforce = 1 * up;
            SfxManager.instance.PlaySfx(SfxManager.Sfx.Focus);
            effect.Effects(1);
        }
    }

    public IEnumerator Wait()
    {
        if (mMUp)
        {
            yield return new WaitForSeconds(2.0f);
            Explosion(1);
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            Explosion(0);
        }
    }
    //매직미사일의 폭파코드
    public GameObject Explosion(int x)
    {
        StopCoroutine(Wait());
        et.x = explodeT.position.x;
        et.y = explodeT.position.y;
        et.z = explodeT.position.z;
        GameObject select = null;

        select = Instantiate(explode[x], et, Quaternion.identity);
        return select;
    }
}
