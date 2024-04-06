
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

//µ¦ÀÇ ¼ÅÇÃ ¹× µå·Î¿ì
public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public List<Card> staticDeck = new List<Card>();

    public List<int> cardGroup = new List<int>();

    public int deckSize;
    public int drawCard;
   
    public GameObject CardToHand;
    GameObject cardCopy;

    void Start()
    {
        deckSize = deck.Count;
      
        for (int i = 0; i < deckSize; i++)
        {
            deck[i] = CardDataBase.cardList[i];
        }
        StartCoroutine(Draw(4));     
    }

    void Update()
    {
        staticDeck = deck;
    }

    public IEnumerator Draw(int x)
    {        
        for (int i = 0; i < x; i++)
        {
            for (int j = i; j < deckSize; j++)
            {
                if (deckSize > 0)
                {
                    yield return new WaitForSeconds(0.01f);
                    cardCopy = Instantiate(CardToHand, transform.position, transform.rotation) as GameObject;
                    Shuffle();

                    break;
                }
            }
        }
    }
       
    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            int randomIndex = Random.Range(i, deck.Count);
            container[0] = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];           
        }       
    }
}
