using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Card클래스를 설정하고 리스트에 넣는다
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

        cardList.Add(new Card(0, "베기", 1, "전방에 약한 참격을 가합니다.", Resources.Load<Sprite>("Sprite/베기"), 1, cardsX0));
        cardList.Add(new Card(1, "내려찍기", 1, "한 방향으로 검을 내려찍습니다.", Resources.Load<Sprite>("Sprite/강타"), 1, cardsX0));
        cardList.Add(new Card(2, "밀치기", 1, "일정 범위의 적들을 중앙 길로 날려서 모으고 일정시간 기절시킵니다.", Resources.Load<Sprite>("Sprite/밀치기"), 1, cardsX0));
        cardList.Add(new Card(3, "매직미사일", cardsX1, "적에게 닿으면 폭발하는 마법구체를 날려보냅니다.", Resources.Load<Sprite>("Sprite/마법"), 1, cardsX1));
        cardList.Add(new Card(4, "회복", 2, " 체력을 10 회복합니다.", Resources.Load<Sprite>("Sprite/회복"), 1, cardsX2));
        cardList.Add(new Card(5, "집중", cardsX2, "이 카드를 사용하고 다음에 사용하는 마나를 사용하지 않는 일반공격들의 데미지는 2배가 됩니다.", Resources.Load<Sprite>("Sprite/집중"), 1, cardsX3));
        cardList.Add(new Card(6, "연속베기", cardsX4, "전방을 강한 힘으로 벱니다.", Resources.Load<Sprite>("Sprite/분노"), 1, cardsX4));
        cardList.Add(new Card(7, "태풍", cardsX5, " 적을 뚫고 지나가는 바람 마법을 사용합니다.", Resources.Load<Sprite>("Sprite/태풍"), 1, cardsX5));
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
