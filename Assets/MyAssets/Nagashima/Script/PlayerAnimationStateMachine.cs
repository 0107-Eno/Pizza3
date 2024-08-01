using UnityEngine;
using UnityEngine.Assertions;

public class PlayerAnimationStateMachine : StateManager<PlayerAnimationStateMachine.PlayerAnimationStates>
{
    /// <summary>
    /// PlayerStateMachine�ň���State�̎��
    /// </summary>
    public enum PlayerAnimationStates
    {
        Idle,
        Movement,
        Jump,
        Action,
        Dead
    }

    private PlayerAnimationStateContext _context;

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovementStateMachine pMovementStateMachine;

    void Awake()
    {
        NullMessage();
        _context = new PlayerAnimationStateContext(_animator,pMovementStateMachine);
        InitializeStates();
    }
    private void NullMessage()
    {
        Assert.IsNotNull(pMovementStateMachine, "_�Ȃ��悤���Ȃ��悤");
    }
    // PlayerStateMachine�Ŏg��State�̏������ƍŏ��ɌĂяo�����State�̎w��
    private void InitializeStates()
    {
        States.Add(PlayerAnimationStates.Idle, new PlayerAnimationIdleState(_context, PlayerAnimationStates.Idle));
        States.Add(PlayerAnimationStates.Movement, new PlayerAnimationMovementState(_context, PlayerAnimationStates.Movement));
        States.Add(PlayerAnimationStates.Jump, new PlayerAnimationJumpState(_context, PlayerAnimationStates.Jump));
        //IdleState���ŏ��ɌĂяo��
        CurrentState = States[PlayerAnimationStates.Idle];
    }
}
