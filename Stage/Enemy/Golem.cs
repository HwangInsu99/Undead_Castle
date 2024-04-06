using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //ÅÂÇ³°ú ºÎµúÈú½Ã ÅÂÇ³ÀÌ »ç¶óÁü
        if (other.CompareTag("Typhoon") || other.CompareTag("RTyphoon"))
            Destroy(other.gameObject, 0.1f);
    }
}
