using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int level;
    float timer;
    int x;
    int monPer;
    public bool BossSummon;

    //�������� �� 5���� ������ ���� ����Ȯ��
    int[] zomPer = { 55, 45, 35, 30, 20 };
    int[] skePer = { 30, 30, 25, 25, 20 };
    int[] sHPer = { 10, 10, 10, 5, 5 };
    int[] gobPer = { 5, 5, 5, 5, 10 };
    int[] staPer = { 0, 5, 10, 15, 20 };
    int[] tStPer = { 0, 5, 5, 10, 15 };
    int[] golPer = { 0, 0, 5, 5, 5 };
    int[] gagPer = { 0, 0, 5, 5, 5 };
    int zom, ske, sH, gob, sta, tSt, gol, gag;

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.instance.gameTime / 20);
        //level = ������ ������ ����
        if (level > 4)
        {
            level = 4;
        }
        //���̺� ������ ��ȯ���� �ʴ� �ð�
        if (Mathf.FloorToInt(GameManager.instance.gameTime % 20) >= 15 && Mathf.FloorToInt(GameManager.instance.gameTime % 20) < 20)
        {
            timer = 0;
        }
        else if (timer > 1)
        {
            Spawn();
            timer = 0;
        }
        //�����ð� �� ��������
        if (GameManager.instance.gameTime >= GameManager.instance.maxGameTime && !BossSummon)
        {
            BossSummon = true;
            BossSpawn();
        }


    }

    public void Spawn()
    {
        zom = zomPer[level];
        ske = zom + skePer[level];
        sH = ske + sHPer[level];
        gob = sH + gobPer[level];
        sta = gob + staPer[level];
        tSt = sta + tStPer[level];
        gol = tSt + golPer[level];
        gag = gol + gagPer[level];

        monPer = Random.Range(0, 99);
        //���庰�� ��ȯ���� �ʴ� ������ Ȯ���� 0������ ������ �߻��� �����ϱ����� �и�
        switch (level)
        {
            case 0:
                if (monPer < zom)
                    x = 0;
                else if (monPer < ske && monPer >= zom)
                    x = 1;
                else if (monPer < sH && monPer >= ske)
                    x = 2;
                else if (monPer < gob && monPer >= sH)
                    x = 3;
                break;
            case 1:
                if (monPer < zom)
                    x = 0;
                else if (monPer < ske && monPer >= zom)
                    x = 1;
                else if (monPer < sH && monPer >= ske)
                    x = 2;
                else if (monPer < gob && monPer >= sH)
                    x = 3;
                else if (monPer < sta && monPer >= gob)
                    x = 4;
                else if (monPer < tSt && monPer >= sta)
                    x = 5;
                break;
            default:
                if (monPer < zom)
                    x = 0;
                else if (monPer < ske && monPer >= zom)
                    x = 1;
                else if (monPer < sH && monPer >= ske)
                    x = 2;
                else if (monPer < gob && monPer >= sH)
                    x = 3;
                else if (monPer < sta && monPer >= gob)
                    x = 4;
                else if (monPer < tSt && monPer >= sta)
                    x = 5;
                else if (monPer < gol && monPer >= tSt)
                    x = 6;
                else if (monPer < gag && monPer >= gol)
                    x = 7;
                break;
        }
        GameManager.instance.enemy.Get(x);
    }

    public void BossSpawn()
    {
        BgmManager.instance.PlayBgm(BgmManager.Bgm.Boss);
        GameManager.instance.enemy.Get(8);
    }
    public void BossSkill()
    {
        int x = 0;
        for (int i = 0; i < 3; i++)
        {
            x = Random.Range(0, 3);
            if (x == 0)
            {
                x = 3;
                GameManager.instance.enemy.Get(x);
            }
            else
            {
                x += 5;
                GameManager.instance.enemy.Get(x);
            }
        }
    }
}