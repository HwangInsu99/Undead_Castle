using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //��ǳ�� �ε����� ��ǳ�� �����
        if (other.CompareTag("Typhoon") || other.CompareTag("RTyphoon"))
            Destroy(other.gameObject, 0.1f);
    }
}
