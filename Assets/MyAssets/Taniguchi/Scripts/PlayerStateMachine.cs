using UnityEngine;
using UnityEngine.Assertions;

public class PlayerStateMachine : StateManager<PlayerStateMachine.PlayerStates>
{
    /// <summary>
    /// PlayerStateMachine�ň���State�̎��
    /// </summary>
    public enum PlayerStates
    {
        Idle,
        Movement,
        Action,
        Dead
    }

    private PlayerStateContext _context;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _col;

    void Awake()
    {
        NullMessage();
        _context = new PlayerStateContext(_rb,_col);
        InitializeStates();
    }
    private void NullMessage()
    {
        Assert.IsNotNull(_rb, "_rb��null�ł�");
    }
    // PlayerStateMachine�Ŏg��State�̏������ƍŏ��ɌĂяo�����State�̎w��
    private void InitializeStates()
    {
        States.Add(PlayerStates.Idle, new PlayerIdleState(_context, PlayerStates.Idle));
        States.Add(PlayerStates.Movement, new PlayerMovementState(_context, PlayerStates.Movement));
        //IdleState���ŏ��ɌĂяo��
        CurrentState = States[PlayerStates.Idle];
    }
}
