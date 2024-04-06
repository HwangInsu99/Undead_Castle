using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public bool Upgraded;
    public UpgradeData upgradeData;
    ManaSystem manaSystem;
    Skill skill;
    Player player;
    CardDataBase cardData;


    Deck deck;

    public int a;
    public int b;

    private void Awake()
    {
        cardData = GameObject.Find("CardDataBase").GetComponent<CardDataBase>();
        manaSystem = GameObject.Find("Mana").GetComponent<ManaSystem>();
        skill = GameObject.Find("Skill").GetComponent<Skill>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

  //선택된 업그레이드를 구별해서 해당클래스에 전달하는역할
    public void OnClick()
    {
        SfxManager.instance.PlaySfx(SfxManager.Sfx.Button);
        Upgraded = true;
       
        switch (upgradeData.Id)
        {
            case 0:
                cardData.CardUpgrade(0);
                skill.ultUp = true;
                break;
            case 1:
                manaSystem.MaxUp();              
                break;
            case 2:
                skill.magicUp = 4;
                break;
            case 3:
                player.killUp = true;
                break;
            case 4:
                skill.stompUp = true;
                break;
            case 5:
                skill.knockUp = true;
                break;
            case 6:
                skill.mMUp = true;
                break;
            case 7:
                skill.dSlashUp = true;
                break;
            case 8:
                cardData.CardUpgrade(1);
                break;
            case 9:
                skill.hUp = true;
                break;
            case 10:
                cardData.CardUpgrade(2);
                break;
            case 11:
                player.ExtraLife = 1;
                break;
            case 12:
                skill.up = 2;
                break;
            case 13:
                skill.slashUp = true;
                break;
        }
        player.levelUp = false;
    }
}
