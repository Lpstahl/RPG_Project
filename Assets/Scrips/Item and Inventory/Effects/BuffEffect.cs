using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartType
{
    strenght,
    agility,
    intelligence,
    vitality,
    damage, 
    critChance,
    CritPower,
    health,
    armor,
    evasion,
    magicRes,
    fireDamage,
    iceDamage,
    lightiningDamage
}

[CreateAssetMenu(fileName = "Buff Effect", menuName = "Data/Item Effect/Buff Effect")]
public class BuffEffect : ItemEffect
{
    private PlayerStats stats;
    [SerializeField] private StartType buffType;
    [SerializeField] private int BuffAmount;
    [SerializeField] private float BuffDuration;

    public override void ExecuteEffect(Transform _enemyPosition)
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        stats.IncreaseStatBy(BuffAmount, BuffDuration, StatToModify());
    }

    private Stat StatToModify()
    {
        if (buffType == StartType.strenght) return stats.strenght;
        else if (buffType == StartType.agility) return stats.agillity;
        else if (buffType == StartType.intelligence) return stats.intelligence;
        else if (buffType == StartType.vitality) return stats.vitality;
        else if (buffType == StartType.damage) return stats.damage;
        else if (buffType == StartType.critChance) return stats.critChance;
        else if (buffType == StartType.CritPower) return stats.critPower;
        else if (buffType == StartType.health) return stats.maxHealth;
        else if (buffType == StartType.armor) return stats.armor;
        else if (buffType == StartType.evasion) return stats.evasion;
        else if (buffType == StartType.magicRes) return stats.magicResistence;
        else if (buffType == StartType.fireDamage) return stats.fireDamage;
        else if (buffType == StartType.iceDamage) return stats.iceDamage;
        else if (buffType == StartType.lightiningDamage) return stats.lightingDamage;

        return null;
    }
}
