using UnityEngine;

public enum ItemType
{
    Material,
    Equipmant
}

[CreateAssetMenu(fileName = "New Item Data", menuName = "data/Item")]
public class ItemData : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite icon;
}
