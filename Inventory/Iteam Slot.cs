using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IteamSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDes;
    public Sprite emptySprite;

    [SerializeField]
    private Text quantityText;

    [SerializeField]
    private Image itemImage;

    public Image itemDescription;
    public Text itemDescriptionName;
    public Text itemDescriptionText;

    public GameObject selectedShader;
    public bool thisIteamSelected;

    private InventoryManager inventoryManager;
    private CardSlot cardSlot;

    void Start()
    {
        inventoryManager = GameObject.Find("EQ").GetComponent<InventoryManager>();
        cardSlot = FindAnyObjectByType<CardSlot>();
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDes = itemDescription;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;

    }

    public void OnLeftClick()
    {
        inventoryManager.DeSelectAllSlots();
        selectedShader.SetActive(true);
        thisIteamSelected = true;
        itemDescriptionName.text = itemName;
        itemDescriptionText.text = itemDes;
        itemDescription.sprite = itemSprite;
        if (itemDescription.sprite == null)
            itemDescription.sprite = emptySprite;
        if (cardSlot.cardDescriptionImage.sprite != null)
            cardSlot.cardDescriptionImage.sprite = emptySprite;
    }

    public void OnRightClick()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }


}
