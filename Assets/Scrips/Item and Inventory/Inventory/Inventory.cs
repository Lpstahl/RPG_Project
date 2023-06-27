using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<InventoryItem> inventoryItem;
    public Dictionary<ItemData, InventoryItem> inventoryDictionary;

    [Header("Inventoy UI")]
    [SerializeField] private Transform inventorySlotParent;

    private ItemSlotUI[] itemSlot;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        inventoryItem = new List<InventoryItem>();
        inventoryDictionary = new Dictionary<ItemData, InventoryItem>();

        itemSlot = inventorySlotParent.GetComponentsInChildren<ItemSlotUI>();
    }

    private void UpdateSlotUI()
    {
        for (int i = 0; i < inventoryItem.Count; i++)
        {
            itemSlot[i].UpdatSlot(inventoryItem[i]);
        }
    }

    public void AddItem(ItemData _item)
    {
        if (inventoryDictionary.TryGetValue(_item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(_item);
            inventoryItem.Add(newItem);
            inventoryDictionary.Add(_item, newItem);
        }

        UpdateSlotUI();
    }

    public void RemoveItem(ItemData _item)
    {
        if (inventoryDictionary.TryGetValue(_item, out InventoryItem value))
        {
            if (value.stackSize <= 1)
            {
                inventoryItem.Remove(value);
                inventoryDictionary.Remove(_item);
            }
            else
                value.RemoveStack();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            ItemData newItem = inventoryItem[inventoryItem.Count - 1].data;

            RemoveItem(newItem);
        }

        UpdateSlotUI();    
    }    
}
