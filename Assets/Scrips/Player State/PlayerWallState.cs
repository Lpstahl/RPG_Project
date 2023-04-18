using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallState : PlayerState
{
    public PlayerWallState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if(player.isWallDetected() == false)
        {
            stateMachine.ChangeState(player.airState);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            stateMachine.ChangeState(player.wallJump);
            return;
        }

        //CHANGE xInput == 0 to xInput != 0. Because was flicking the wall slide animation and this change works
        if(xInput != 0 && player.facingDir == xInput)
        {                  
                stateMachine.ChangeState(player.idleState);          
        }

        if (yInput < 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);            
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y * .7f);            
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
