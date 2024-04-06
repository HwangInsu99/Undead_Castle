using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//카드패의 컨트롤
public class CardDisplay : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public int cardId;
    public Deck deckList;
    public Draggable d;
    public static CardDisplay instance;

    public GameObject CardToHand;

    public int id;
    public string cardName;
    public int cost;
    public string cardDescription;

    public Sprite spriteImage;

    public Text nameText;
    public Text costText;
    public Text descriptionText;
    public Image artworkMaskImage;

    public HandZone Hand;
    public int numOfCardsInDeck;

    public  static int drawX;
    public int drawXcards;

    public int costX;
    public int costXcards;

    public int cardID;

    public GameObject dropZone;

    public bool dropInput;
    public bool dropOutput;

    public bool isChecked;
    public bool isDropped;
    CardDataBase cardData;

    void Awake()
    {
        deckList = FindObjectOfType<Deck>(); 
        Hand = FindObjectOfType<HandZone>();
        cardData = FindObjectOfType<CardDataBase>();
        d = gameObject.GetComponent<Draggable>();
        instance = this;
    }
    void Start()
    {
        cards[0] = CardDataBase.cardList[cardId];

        numOfCardsInDeck = deckList.deckSize;

        dropInput = false;
        dropOutput = false;
        isDropped = false;
        isChecked = false;

        drawX = 0;
    }
    //드로우할 카드가 현재패에 있는지 확인 후 재셔플또는 드로우
    public IEnumerator isCardChecked()
    {
        foreach (var duplicate in deckList.cardGroup)
        {
            if (duplicate == deckList.deck[deckList.deck.Count - 1].id)
            {
                deckList.Shuffle();
                continue;
            }

            else if (duplicate != deckList.deck[deckList.deck.Count - 1].id)
            {
                StartCoroutine(deckList.Draw(drawX));
                drawX = 0;               
                continue;
            }
        }
        yield return new WaitForSeconds(0.001f);
    }

    public void CardInfo()
    {
        //내 패의 카드들의 정보를 카드에서 받아와서 설정
        id = cards[0].id;
        cardName = cards[0].cardName;
        cardDescription = cards[0].cardDescription;
        spriteImage = cards[0].spriteImage;

        drawXcards = cards[0].drawXcards;

        if (id == 0 || id == 1 || id == 2)
        {
            costXcards = cardData.cardsX0;
            cost = cardData.cardsX0;
        }
        else if (id == 3)
        {
            costXcards = cardData.cardsX1;
            cost = cardData.cardsX1;
        }
        else if (id == 4)
        {
            costXcards = cardData.cardsX2;
            cost = cardData.cardsX2;
        }
        else if (id == 5)
        {
            costXcards = cardData.cardsX3;
            cost = cardData.cardsX3;
        }
        else if (id == 6)
        {
            costXcards = cardData.cardsX4;
            cost = cardData.cardsX4;
        }
        else if (id == 7)
        {
            costXcards = cardData.cardsX5;
            cost = cardData.cardsX5;
        }

        nameText.text = cardName;
        costText.text = cost.ToString();

        descriptionText.text = cardDescription;

        artworkMaskImage.sprite = spriteImage;

        cardID = cards[0].id;
    }

    public void StopDraw()
    {
        //코스트가 부족할때 코스트사용카드를 사용했을시 드로우하지않음
        if (cardID == 6 || cardID == 7)
        {
            if (ManaSystem.currnetMana < 3)
            {
                drawX = 0;
                StopCoroutine(deckList.Draw(drawX));
            }
        }
    }

    public void isDrop()
    {
        dropInput = true;
        drawX = drawXcards;

        deckList.cardGroup.Remove(cardID);

        StopDraw();
    }

    public void isDropChecked()
    {
        if (dropInput == false)
        {
            dropOutput = true;
        }
        else
            dropOutput = false;

        if (dropOutput == true)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
        }

        else
            gameObject.GetComponent<Draggable>().enabled = false;

        dropZone = GameObject.Find("DropZone");

        if (isChecked == true)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
        }

        if (dropInput == false && this.transform.parent == dropZone.transform)
        {       
            isDrop();
        }
    }

    void Update()
    {
        CardInfo();
        StartCoroutine(isCardChecked());
        isDropChecked();

        if (this.tag == "Clone")
        {
            cards[0] = deckList.staticDeck[numOfCardsInDeck - 1];

            foreach (Card card in cards)
            {
                deckList.cardGroup.Add(card.id);
                
            }
            this.tag = "Untagged";
        }
    }
}
