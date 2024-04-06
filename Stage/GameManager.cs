using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameTime;
    public float maxGameTime;

    public EnemyManager enemy;
    public Player player;
    public Skill skill;
    public LevelUp uiLevelUp;

    void Awake()
    {
        instance = this;
        maxGameTime = 2 * 59f;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void Levelup()
    {
        uiLevelUp.Show();
    }

}
