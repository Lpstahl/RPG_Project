using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSkill : Skill
{
    [SerializeField] private int amountOfAttacks;
    [SerializeField] private float cloneCooldown;
    [SerializeField] private GameObject blackHolePref;
    [Space]
    [SerializeField] private float maxSize;
    [SerializeField] private float growSpeed;
    [SerializeField] private float shrinkSpeed;

    public override bool CanUseSkill()
    {
        return base.CanUseSkill();
    }

    public override void UseSkill()
    {
        base.UseSkill();

        GameObject newBlackHole = Instantiate(blackHolePref);

        BlackHoleSkillController newBlackHoleScript = newBlackHole.GetComponent<BlackHoleSkillController>();

        newBlackHoleScript.SetUpBlackHole(maxSize, growSpeed, shrinkSpeed, amountOfAttacks, cloneCooldown);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
