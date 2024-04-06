using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ȸ�� �г� ��ġ���� ����Ʈ
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
