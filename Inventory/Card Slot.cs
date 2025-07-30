using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IPointerClickHandler
{
    public string cardName;
    public Sprite cardSprite;
    public bool isFullCard;
    public string cardDescription;
    public Sprite emptyCard;

    [SerializeField]
    private Image cardImage;

    public Image cardDescriptionImage;
    public Text cardDescriptionName;
    public Text cardDescriptionText;

    public GameObject selectedCard;
    public bool thisCardSelected;

    private InventoryManager inventoryManager;
    private IteamSlot iteamSlot;

    void Start()
    {
        inventoryManager = GameObject.Find("EQ").GetComponent<InventoryManager>();
        iteamSlot = FindAnyObjectByType<IteamSlot>();
    }

    public void AddCard(string cardName, Sprite cardSprite, string cardDescription)
    {
        this.cardName = cardName;
        this.cardSprite = cardSprite;
        this.cardDescription = cardDescription;
        isFullCard = true;

        cardImage.sprite = cardSprite;
    }

    public void OnLeftClikcCard()
    {
        inventoryManager.DeSelectAllSlots();
        selectedCard.SetActive(true);
        thisCardSelected = true;
        cardDescriptionName.text = cardName;
        cardDescriptionText.text = cardDescription;
        cardDescriptionImage.sprite = cardSprite;
        if (cardDescriptionImage.sprite == null)
            cardDescriptionImage.sprite = emptyCard;
        if (iteamSlot.itemDescription.sprite != null)
            iteamSlot.itemDescription.sprite = emptyCard;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClikcCard();
        }
    }
}
