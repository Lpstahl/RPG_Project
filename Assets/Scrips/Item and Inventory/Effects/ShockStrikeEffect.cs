using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thunder strike Effect", menuName = "Data/Item effect/ThunderStrike")]
public class ShockStrikeEffect : ItemEffect
{
    [SerializeField] private GameObject thunderStrikePref;

    public override void ExecuteEffect(Transform _enemyPosition)
    {
        base.ExecuteEffect(_enemyPosition);

        GameObject newThunderStrike = Instantiate(thunderStrikePref, _enemyPosition.position, Quaternion.identity);
        Destroy(newThunderStrike, 1);
    }
}
