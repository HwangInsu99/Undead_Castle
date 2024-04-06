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

    //ī�带 ������� ������� �� ī����
    public void OnDrop(PointerEventData eventData)
    {
        d = eventData.pointerDrag.GetComponent<Draggable>();

        cardDisplay = d.GetComponent<CardDisplay>();
        deckQuantity.deckSize = 8;

        
        dropCard = cardDisplay.cards[0].id;

        d.parentToReturnTo = this.transform;
        //������ ������ �� ��ӵǵ� ī��ȿ���� �ߵ���������
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

    //�����ٸ� ���縶���� ����ؼ� ä��
    void Update()
    {
        if(ManaSystem.maxPlayerMana == 4)
            barImage.fillAmount = ManaSystem.currnetMana * 0.25f;

        else if(ManaSystem.maxPlayerMana == 6)
            barImage.fillAmount = ManaSystem.currnetMana * 0.167f;
    }
}