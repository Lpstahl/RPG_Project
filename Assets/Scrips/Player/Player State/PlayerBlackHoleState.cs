using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlackHoleState : PlayerState
{
    private float flyTime = .4f;
    private bool skillUsed;

    public PlayerBlackHoleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();

        skillUsed = false;
        stateTimer = flyTime;
        rb.gravityScale = 0;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer > 0)
        {
            rb.velocity = new Vector2(0, 15);
        }
        if(stateTimer < 0)
        {
            rb.velocity = new Vector2(0, -1f);
            if(!skillUsed)
            {
                if (player.skill.blackHole.CanUseSkill())
                {
                skillUsed = true;
                }
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
