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
        //���݂̃X�e�[�g�̏���
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

        //�X�e�[�g���؂�ւ������
        if (_state != _nextState)
        {
            //�I�����������s
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
            //���̃X�e�[�g�ɑJ��
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

    //�X�e�[�g��J��
    private void ChangeState(State nextState)
    {
        _nextState = nextState;
    }
    //-------------------------------------
    //IdleState�Ǘ�
    private void IdleStart()
    {
        Debug.Log("IdleState�J�n");
    }
    private void IdleUpdate()
    {
        ChangeState(State.Movement);
    }
    private void IdleEnd()
    {
        Debug.Log("IdleState�I��");
    }
    //-------------------------------------
    //MovementState�Ǘ�
    private void MovementStart()
    {
        Debug.Log("MovementState�J�n");
    }
    private void MovementUpdate()
    {
        _agent.SetDestination(transform.position);
    }
    private void MovementEnd()
    {
        Debug.Log("MovementState�I��");
    }
    //-------------------------------------
    //DeadState�Ǘ�
    private void DeadStart()
    {
        Debug.Log("DeadState�J�n");
    }
    private void DeadUpdate()
    {

    }
    private void DeadEnd()
    {
        Debug.Log("DeadState�I��");
    }
}
