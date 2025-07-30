using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private string cardName;

    [SerializeField]
    private Sprite cardSprite;

    [TextArea]
    [SerializeField]
    private string cardDescription;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("EQ").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventoryManager.AddCard(cardName, cardSprite, cardDescription);
            Destroy(gameObject);
        }
    }

}
