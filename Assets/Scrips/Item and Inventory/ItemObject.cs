using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private SpriteRenderer sr;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ItemData ItemData;

    private void SetUpVisuals()
    {
        if (ItemData == null)
            return;

        GetComponent<SpriteRenderer>().sprite = ItemData.icon;
        gameObject.name = "Item Object - " + ItemData.itemName;
    }

    public void SetUpItem(ItemData _itemData, Vector2 _velocity)
    {
        ItemData = _itemData;
        rb.velocity = _velocity;

        SetUpVisuals();
    }

    public void PickUpItem()
    {
        Inventory.instance.AddItem(ItemData);
        Destroy(gameObject);
    }
}
