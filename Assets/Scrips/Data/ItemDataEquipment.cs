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

    [Header("Major stats")]
    public int strenght;
    public int agility;
    public int intelligence;
    public int vitality;
    
    [Header("Offensive stats")]
    public int damage;
    public int critChance;
    public int critPower;

    [Header("Deffensive stats")]
    public int health;
    public int armor;
    public int evasion;
    public int magicResistence; 
    
    [Header("Magic stats")]
    public int fireDamage;
    public int iceDamage;
    public int lightiningDamage;

    public void AddModifier()
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        playerStats.strenght.AddModifier(strenght);
        playerStats.agillity.AddModifier(agility);
        playerStats.intelligence.AddModifier(intelligence);
        playerStats.vitality.AddModifier(vitality);
        
        playerStats.damage.AddModifier(damage);
        playerStats.critChance.AddModifier(critChance);
        playerStats.critPower.AddModifier(critPower);
        
        playerStats.maxHealth.AddModifier(health);
        playerStats.armor.AddModifier(armor);
        playerStats.evasion.AddModifier(evasion);
        playerStats.magicResistence.AddModifier(magicResistence);
        
        playerStats.fireDamage.AddModifier(fireDamage);
        playerStats.iceDamage.AddModifier(iceDamage);
        playerStats.lightingDamage.AddModifier(lightiningDamage);
    }

    public void RemoveModifier()
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        playerStats.strenght.RemoveModifier(strenght);
        playerStats.agillity.RemoveModifier(agility);
        playerStats.intelligence.RemoveModifier(intelligence);
        playerStats.vitality.RemoveModifier(vitality);

        playerStats.damage.RemoveModifier(damage);
        playerStats.critChance.RemoveModifier(critChance);
        playerStats.critPower.RemoveModifier(critPower);

        playerStats.maxHealth.RemoveModifier(health);
        playerStats.armor.RemoveModifier(armor);
        playerStats.evasion.RemoveModifier(evasion);
        playerStats.magicResistence.RemoveModifier(magicResistence);

        playerStats.fireDamage.RemoveModifier(fireDamage);
        playerStats.iceDamage.RemoveModifier(iceDamage);
        playerStats.lightingDamage.RemoveModifier(lightiningDamage);
    }
}
