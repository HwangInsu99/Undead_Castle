using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//근접스킬의 이펙트를 칼 위치에 맞춰서 나타냄
public class ESword : MonoBehaviour
{
    public GameObject[] prefabs;

    public List<GameObject>[] eSword;


    void Awake()
    {
        eSword = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < eSword.Length; index++)
        {
            eSword[index] = new List<GameObject>();
        }
    }
    public GameObject ESwords(int index)
    {
        GameObject select = null;

        select = Instantiate(prefabs[index], transform);
        eSword[index].Add(select);
        return select;
    }

}
