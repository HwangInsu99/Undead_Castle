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
    SoundOptions soundOptions;


    void Awake()
    {
        instance = this;
        maxGameTime = 2 * 59f;
        if (GameObject.Find("SoundManager") != null)
        {
            soundOptions = GameObject.Find("SoundManager").GetComponent<SoundOptions>();
            soundOptions.delete();
        }
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