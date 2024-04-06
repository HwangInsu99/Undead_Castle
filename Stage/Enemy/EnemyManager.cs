using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] prefabs;

    public List<GameObject>[] enemies;
    //만들어진 Enemy들을 매니저의 자식으로서 보관
    void Awake()
    {
        enemies = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < enemies.Length; index++)
        {
            enemies[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        
        select = Instantiate(prefabs[index], transform);
        enemies[index].Add(select);
        return select;
    }
}
