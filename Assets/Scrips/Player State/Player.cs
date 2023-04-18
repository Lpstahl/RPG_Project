using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Attack Details")]
    public Vector2[] attackMovement;

    public bool isBusy {  get; private set; }
    [Header("Move Info")]
    public float moveSpeed = 12f;
    public float jumpForce;

    [Header("Dash Info")]
    [SerializeField] private float dashCoolDown;
    private float dashUsageTime;
    public float dashSpeed;
    public float dashDuration;
    public float dashDirection { get; private set; }

    [Header("Collision Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;


    public int facingDir { get; private set; }
    private bool facingRight = true;
  
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    #endregion

    #region State
    public PlayerStateMachine stateMachine {  get; private set; }
    public PlayerState idleState { get; private set; }  
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; } 
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallState wallSlide { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }

    public PlayerPrimaryAttackState primaryAttack { get; private set; }
    
    
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlide = new PlayerWallState(this, stateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");

        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>(); 
        rb = GetComponent<Rigidbody2D>();

        stateMachine.Initialize(idleState);

    }

    private void Update()
    {
        stateMachine.currentState.Update();

        Debug.Log(isWallDetected());
        CheckForDashInput();
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_seconds);

        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    private void CheckForDashInput()
    {
        if(isWallDetected())
        {
            return;
        }

        dashUsageTime -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTime < 0) 
        {
            dashUsageTime = dashCoolDown;
            dashDirection = Input.GetAxisRaw("Horizontal");

            if(dashDirection == 0)
            {
                dashDirection = facingDir;
            }

            stateMachine.ChangeState(dashState);
        }
    }
    #region Velocity
    public void ZeroVelocty()
    {
        rb.velocity = new Vector2(0, 0);
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipControl(_xVelocity);
    }
    #endregion
    #region Collision
    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public bool isWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y -groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3 (wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
    #endregion
    #region Flip
    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;

        transform.Rotate(0, 180, 0);
    }

    public void FlipControl(float _x)
    {
        if(_x > 0 && !facingRight)
        {
            Flip();
        }
        else if(_x < 0 && facingRight)
        {
            Flip();
        }
    }
    #endregion
}
