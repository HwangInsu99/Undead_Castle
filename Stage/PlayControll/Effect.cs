using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//회복 분노 밀치기의 이펙트
public class Effect : MonoBehaviour
{
    public GameObject[] prefabs;

    public List<GameObject>[] effects;

    void Awake()
    {
        effects = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < effects.Length; index++)
        {
            effects[index] = new List<GameObject>();
        }
    }
    public GameObject Effects(int index)
    {
        GameObject select = null;

        select = Instantiate(prefabs[index], transform);
        effects[index].Add(select);
        return select;
    }
}
