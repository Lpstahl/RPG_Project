using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemDrop : ItemDrop
{
    [Header("Player´s drop")]
    [SerializeField] private float chanceToLooseItem;
    [SerializeField] private float chanceToLooseMaterials;
    

    public override void GenerateDrop()
    {
        Inventory inventory = Inventory.instance;

        List<InventoryItem> ItemsToUnquip = new List<InventoryItem>();
        List<InventoryItem> materialsToLoose = new List<InventoryItem>();

        foreach (InventoryItem Item in inventory.GetEquipmentList())
        {
            if ( Random.Range(0, 100) <= chanceToLooseItem )
            {
                DropItem(Item.data);
            }
        }

        for (int i = 0; i < ItemsToUnquip.Count; i++)
        {
                inventory.UnequipItem(ItemsToUnquip[i].data as ItemDataEquipment);
        }

        foreach (InventoryItem Item in inventory.GetStashList())
        {
            if (Random.Range(0, 100) <= chanceToLooseMaterials)
            {
                DropItem(Item.data);
                materialsToLoose.Add(Item);
            }
        }

        for (int i = 0; i < materialsToLoose.Count; i++)
        {
            inventory.RemoveItem(materialsToLoose[i].data);
        }
    }
}
