using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//��ų���� ����Ʈ�� �����ϴ��ڵ�
public class EffectDelete : MonoBehaviour
{
    public float DTime;
    public void Start()
    {
        Destroy(gameObject, DTime);
    }
}
