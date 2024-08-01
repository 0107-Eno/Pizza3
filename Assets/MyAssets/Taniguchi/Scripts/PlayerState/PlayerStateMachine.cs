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
        Dead
    }

    private PlayerStateContext _context;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _col;
    [SerializeField] private Transform _myTransform;
    [SerializeField] private GameObject _enemyObject;
    [SerializeField] private float _playerSpeed = 30;

    void Awake()
    {
        NullMessage();
        _context = new PlayerStateContext(_rb,_col,_playerSpeed,_myTransform,_enemyObject);
        InitializeStates();
    }

    private void NullMessage()
    {
        Assert.IsNotNull(_rb, "_rb��null�ł�");
        Assert.IsNotNull(_col, "_col��null�ł�");
        Assert.IsNotNull(_enemyObject, "_col��null�ł�");
    }
    // PlayerStateMachine�Ŏg��State�̏������ƍŏ��ɌĂяo�����State�̎w��
    private void InitializeStates()
    {
        States.Add(PlayerStates.Idle, new PlayerIdleState(_context, PlayerStates.Idle));
        States.Add(PlayerStates.Movement, new PlayerMovementState(_context, PlayerStates.Movement));
        States.Add(PlayerStates.Dead, new PlayerDeadState(_context, PlayerStates.Dead));
        //IdleState���ŏ��ɌĂяo��
        CurrentState = States[PlayerStates.Idle];
    }
}
