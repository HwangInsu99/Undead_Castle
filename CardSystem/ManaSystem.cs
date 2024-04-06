using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaSystem : MonoBehaviour
{

    public static int maxPlayerMana;
    public static int currnetMana;

    public Text playerManaText;

    public static int changeMana;

    void Start()
    {
        StartCoroutine(Timer());
        maxPlayerMana = 4;
        currnetMana = 0;
    }

    void Update()
    {
        CardCost();
    }
    public void MaxUp()
    {
        maxPlayerMana = 6;      
    }

    public void CardCost()
    {
        playerManaText.text = "<color=#F5F5F5>" + currnetMana + "</color>" + "<color=#F5F5F5>" + "/" + "</color>" 
                               + "<color=#F0F8FF>" + maxPlayerMana + "</color>";
    }

    IEnumerator Timer()
    {
        if (currnetMana < maxPlayerMana && currnetMana >= 0)
        {
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(Timer());
        }
    }
}
