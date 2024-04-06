using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CardŬ������ �����ϰ� ����Ʈ�� �ִ´�
public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    public int cardsX0, cardsX1, cardsX2, cardsX3, cardsX4, cardsX5;

    Deck deckList;

    private void Start()
    {
        deckList = FindObjectOfType<Deck>();

        cardsX0 = 1;
        cardsX1 = 0;
        cardsX2 = 2;
        cardsX3 = 0;
        cardsX4 = -2;
        cardsX5 = -3;

        cardList.Add(new Card(0, "����", 1, "���濡 ���� ������ ���մϴ�.", Resources.Load<Sprite>("Sprite/����"), 1, cardsX0));
        cardList.Add(new Card(1, "�������", 1, "�� �������� ���� ��������ϴ�.", Resources.Load<Sprite>("Sprite/��Ÿ"), 1, cardsX0));
        cardList.Add(new Card(2, "��ġ��", 1, "���� ������ ������ �߾� ��� ������ ������ �����ð� ������ŵ�ϴ�.", Resources.Load<Sprite>("Sprite/��ġ��"), 1, cardsX0));
        cardList.Add(new Card(3, "�����̻���", cardsX1, "������ ������ �����ϴ� ������ü�� ���������ϴ�.", Resources.Load<Sprite>("Sprite/����"), 1, cardsX1));
        cardList.Add(new Card(4, "ȸ��", 2, " ü���� 10 ȸ���մϴ�.", Resources.Load<Sprite>("Sprite/ȸ��"), 1, cardsX2));
        cardList.Add(new Card(5, "����", cardsX2, "�� ī�带 ����ϰ� ������ ����ϴ� ������ ������� �ʴ� �Ϲݰ��ݵ��� �������� 2�谡 �˴ϴ�.", Resources.Load<Sprite>("Sprite/����"), 1, cardsX3));
        cardList.Add(new Card(6, "���Ӻ���", cardsX4, "������ ���� ������ ���ϴ�.", Resources.Load<Sprite>("Sprite/�г�"), 1, cardsX4));
        cardList.Add(new Card(7, "��ǳ", cardsX5, " ���� �հ� �������� �ٶ� ������ ����մϴ�.", Resources.Load<Sprite>("Sprite/��ǳ"), 1, cardsX5));
    }
    public void CardUpgrade(int x)
    {
        switch (x)
        {
            case 0:
                cardsX4 -= 1;
                cardsX5 -= 1;
                cardList[6].cost -= 1;
                cardList[7].cost -= 1;
                break;
            case 1:
                cardsX1 += 1;
                cardList[3].cost += 1;
                break;
            case 2:
                cardsX3 += 1;
                cardList[5].cost += 1;
                break;
        }
    }

}
