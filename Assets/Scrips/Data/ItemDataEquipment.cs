using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EquipmantType
{
    Weapon,
    Armor,
    Amulet,
    Flask
}

[CreateAssetMenu(fileName = "New Item Data", menuName = "data/Equipmant")]
public class ItemDataEquipment : ItemData
{
    public EquipmantType equipmantType;
}
