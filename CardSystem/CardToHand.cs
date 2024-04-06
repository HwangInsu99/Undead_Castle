using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ī�带 �ڵ��� �������� ��ġ�� ����
public class CardToHand : MonoBehaviour
{
    public static GameObject Hand;
    public GameObject HandCard;
    
    void Start()
    {
        Hand = GameObject.Find("Hand");
        HandCard.transform.SetParent(Hand.transform);
        HandCard.transform.localScale = Vector3.one;
        HandCard.transform.position = new Vector3(Hand.transform.position.x, Hand.transform.position.y, Hand.transform.position.z);
        HandCard.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
