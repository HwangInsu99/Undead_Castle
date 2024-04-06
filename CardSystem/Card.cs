using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
//ī���� ����
public class Card
{
    public int id;
    public string cardName;
    public int cost; 
    public string cardDescription;  
    public Sprite spriteImage;
    public int drawXcards;
    public int costXcards;

    public Card(int Id, string CardName, int Cost, string CardDescription, Sprite SpriteImage, int DrawXcards, int CostXcards)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;      
        cardDescription = CardDescription;     
        spriteImage = SpriteImage;
        drawXcards = DrawXcards;
        costXcards = CostXcards;
    }
}
