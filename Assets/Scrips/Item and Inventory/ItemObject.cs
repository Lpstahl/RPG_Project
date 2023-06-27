using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private SpriteRenderer sr;

    [SerializeField] private ItemData ItemData;

    private void OnValidate()
    {
        GetComponent<SpriteRenderer>().sprite = ItemData.icon;
        gameObject.name = "Item Object - " + ItemData.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.GetComponent<Player>() != null)
        {
            Inventory.Instance.AddItem(ItemData);
            Destroy(gameObject);
        }
    }
}
