using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thunder strike Effect", menuName = "Data/Item effect/ShockStrike")]
public class ShockStrikeEffect : ItemEffect
{
    [SerializeField] private GameObject shockStrikePref;

    public override void ExecuteEffect(Transform _enemyPosition)
    {
        base.ExecuteEffect(_enemyPosition);

        GameObject newShockStrike = Instantiate(shockStrikePref, _enemyPosition.position, Quaternion.identity);
        Destroy(newShockStrike, 1);
    }
}
