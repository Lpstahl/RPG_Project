
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        float xOffset;

        if (Random.Range(0, 100) > 50)
        {
            xOffset = .1f;
        }
        else
        {
            xOffset = -.1f;
        }

        player.skill.clone.CreateClone(player.transform, new Vector3(xOffset, 0));

        stateTimer = player.dashDuration;
    }

    public override void Update()
    {
        base.Update();

        if (!player.IsGroundDetected() && player.isWallDetected())
        {
            stateMachine.ChangeState(player.wallSlide);
        }

        player.SetVelocity(player.dashSpeed * player.dashDirection, 0);

        if (stateTimer < 0)
            stateMachine.ChangeState(player.idleState);
    }
    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0, rb.velocity.y);
    }
}
