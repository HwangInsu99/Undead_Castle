using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    private Draggable d;
    private CardDisplay cardDisplay;
    private Deck deckQuantity;
    private Upgrade changeMana;
  
    private int dropCard;

    private HandZone Hand;

    public Image barImage;

    void Awake()
    {
        deckQuantity = FindObjectOfType<Deck>();
        Hand = FindObjectOfType<HandZone>();
       
        ManaSystem.currnetMana = 0;
    }

    //카드를 드롭존에 드롭했을 시 카드사용
    public void OnDrop(PointerEventData eventData)
    {
        d = eventData.pointerDrag.GetComponent<Draggable>();

        cardDisplay = d.GetComponent<CardDisplay>();
        deckQuantity.deckSize = 8;

        
        dropCard = cardDisplay.cards[0].id;

        d.parentToReturnTo = this.transform;
        //마나가 부족할 시 드롭되도 카드효과를 발동하지않음
        if (dropCard == 6 || dropCard == 7)
        {
            if (ManaSystem.currnetMana >= cardDisplay.costXcards * -1)
            {
                ManaSystem.currnetMana += cardDisplay.costXcards;
                Update();
                GameManager.instance.skill.ActiveSkill(dropCard);

                StartCoroutine(deckQuantity.Draw(cardDisplay.cards[0].drawXcards));
                CardDisplay.drawX = 0;

                deckQuantity.cardGroup.Remove(dropCard);
                Destroy(eventData.pointerDrag, 0.1f);
            }
        }

        else
        {
            GameManager.instance.skill.ActiveSkill(dropCard);
            ManaSystem.currnetMana += cardDisplay.costXcards;
            Destroy(eventData.pointerDrag, 0.2f);
        }

        if (ManaSystem.currnetMana > ManaSystem.maxPlayerMana)
            ManaSystem.currnetMana = ManaSystem.maxPlayerMana;

        else if (ManaSystem.currnetMana <= 0)
            ManaSystem.currnetMana = 0;
    }

    //마나바를 현재마나에 비례해서 채움
    void Update()
    {
        if(ManaSystem.maxPlayerMana == 4)
            barImage.fillAmount = ManaSystem.currnetMana * 0.25f;

        else if(ManaSystem.maxPlayerMana == 6)
            barImage.fillAmount = ManaSystem.currnetMana * 0.167f;
    }
}