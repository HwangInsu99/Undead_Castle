using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//투사체스킬의 생성
public class Range : MonoBehaviour
{
    public GameObject[] prefabs;

    public List<GameObject>[] skills;

    public int x;

    void Awake()
    {
        skills = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < skills.Length; index++)
        {
            skills[index] = new List<GameObject>();
        }
    }
    public GameObject Fire(int index)
    {
        GameObject select = null;

        if(index >= 4)
        {
            for(int i = 0; i < 3; i++)
            {
                x = i;
                select = Instantiate(prefabs[(index-4) * 3 + i], transform);
                skills[(index - 4) * 3 + i].Add(select);
            }
        }
        else
        {
            select = Instantiate(prefabs[index*3], transform);
            skills[index*3].Add(select);
        }
        return select;
    }
}
