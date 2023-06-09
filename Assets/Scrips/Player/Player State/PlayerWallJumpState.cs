using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = .1f;
        player.SetVelocity(5 * -player.facingDir, player.jumpForce);
    }

    public override void Update()
    {
        base.Update();

        //Change stateTimer = 0 to < .1f because the player was looking to otherside when jump for a little sec and then look to correct side and thats was bothering me.
        if(stateTimer < .1f)
        {
            stateMachine.ChangeState(player.airState);
        }

        if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
