using UnityEngine;
using UnityEngine.AI;

public class PlayerStateMachine : MonoBehaviour
{
    private enum State
    {
        Idle,
        Movement,
        Dead
    }
    private State _state = State.Idle;
    private State _nextState = State.Idle;

    private Transform _target;
    private NavMeshAgent _agent;
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find("Player").transform;
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _agent = GetComponent<NavMeshAgent>();
        IdleStart();
    }

    // Update is called once per frame
    void Update()
    {
        //現在のステートの処理
        switch (_state)
        {
            case State.Idle:
                IdleUpdate();
                break;
            case State.Movement:
                MovementUpdate();
                break;
            case State.Dead:
                DeadUpdate();
                break;
        }

        //ステートが切り替わったら
        if (_state != _nextState)
        {
            //終了処理を実行
            switch (_state)
            {
                case State.Idle:
                    IdleEnd();
                    break;
                case State.Movement:
                    MovementEnd();
                    break;
                case State.Dead:
                    DeadEnd();
                    break;
            }
            //次のステートに遷移
            _state = _nextState;
            switch (_state)
            {
                case State.Idle:
                    IdleStart();
                    break;
                case State.Movement:
                    MovementStart();
                    break;
                case State.Dead:
                    DeadStart();
                    break;
            }
        }
    }

    //ステートを遷移
    private void ChangeState(State nextState)
    {
        _nextState = nextState;
    }
    //-------------------------------------
    //IdleState管理
    private void IdleStart()
    {
        Debug.Log("IdleState開始");
    }
    private void IdleUpdate()
    {
        ChangeState(State.Movement);
    }
    private void IdleEnd()
    {
        Debug.Log("IdleState終了");
    }
    //-------------------------------------
    //MovementState管理
    private void MovementStart()
    {
        Debug.Log("MovementState開始");
    }
    private void MovementUpdate()
    {
        _agent.SetDestination(transform.position);
    }
    private void MovementEnd()
    {
        Debug.Log("MovementState終了");
    }
    //-------------------------------------
    //DeadState管理
    private void DeadStart()
    {
        Debug.Log("DeadState開始");
    }
    private void DeadUpdate()
    {

    }
    private void DeadEnd()
    {
        Debug.Log("DeadState終了");
    }
}
