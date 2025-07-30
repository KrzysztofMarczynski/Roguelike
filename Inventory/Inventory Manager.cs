using Unity.Properties;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public IteamSlot[] iteamSlot;
    public CardSlot[] cardSlot;

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < iteamSlot.Length; i++)
        {
            if (iteamSlot[i].isFull == false)
            {
                iteamSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                return;
            }
        }
    }

    public void AddCard(string cardName, Sprite cardSprite, string cardDescription)
    {
        for (int i = 0; i < cardSlot.Length; i++)
        {
            if (cardSlot[i].isFullCard == false)
            {
                cardSlot[i].AddCard(cardName, cardSprite, cardDescription);
                return;
            }
        }
    }

    public void DeSelectAllSlots()
    {
        for (int i = 0; i < iteamSlot.Length; i++)
        {
            iteamSlot[i].selectedShader.SetActive(false);
            iteamSlot[i].thisIteamSelected = false;
        }
        for (int i = 0; i < cardSlot.Length; i++)
        {
            cardSlot[i].selectedCard.SetActive(false);
            cardSlot[i].thisCardSelected = false;
        }
    }
}
