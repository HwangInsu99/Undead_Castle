using UnityEngine;
//스킬들의 이펙트를 삭제하는코드
public class EffectDelete : MonoBehaviour
{
    public float DTime;
    public void Start()
    {
        Destroy(gameObject, DTime);
    }
}