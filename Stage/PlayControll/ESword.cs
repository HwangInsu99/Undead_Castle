using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//������ų�� ����Ʈ�� Į ��ġ�� ���缭 ��Ÿ��
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
