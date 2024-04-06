using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] prefabs;

    public List<GameObject>[] enemies;
    //������� Enemy���� �Ŵ����� �ڽ����μ� ����
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
