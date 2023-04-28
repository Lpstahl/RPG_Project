using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashSkill : Skill
{
    public override void UseSkill()
    {
        base.UseSkill();

        Debug.Log("Create Clone Behind");
    }
}
