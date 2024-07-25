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
        Action,
        Dead
    }

    private PlayerAnimationStateContext _context;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _col;
    [SerializeField] private Animator _animator;

    void Awake()
    {
        NullMessage();
        _context = new PlayerAnimationStateContext(_rb, _col,_animator);
        InitializeStates();
    }
    private void NullMessage()
    {
        Assert.IsNotNull(_rb, "_rb��null�ł�");
    }
    // PlayerStateMachine�Ŏg��State�̏������ƍŏ��ɌĂяo�����State�̎w��
    private void InitializeStates()
    {
        States.Add(PlayerAnimationStates.Idle, new PlayerAnimationIdleState(_context, PlayerAnimationStates.Idle));
        //IdleState���ŏ��ɌĂяo��
        CurrentState = States[PlayerAnimationStates.Idle];
    }
}
