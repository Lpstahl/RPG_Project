using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlotUI : ItemSlotUI
{
    public EquipmantType slotType;

    private void OnValidate()
    {
        gameObject.name = "EquipSlot - " + slotType.ToString();
    }
}
