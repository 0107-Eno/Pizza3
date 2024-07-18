using UnityEngine;

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

    private Rigidbody _rb;
    private Rigidbody _targetrb;
    private Vector3 _playerPos;
    [SerializeField] private float _force = 400;
    [SerializeField] private float _speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        _rb = GetComponent<Rigidbody>();
        _playerPos = GetComponent<Transform>().position;
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
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector3(x * _speed, 0, z * _speed);
        Vector3 _diff = transform.position - _playerPos;
        if (_diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(_diff);
        }
        _playerPos = transform.position;
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
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            _targetrb = col.gameObject.GetComponent<Rigidbody>();

            Vector3 posA = transform.position;
            Vector3 posB = col.transform.position;
            Vector3 direction = (posB - posA).normalized;

            _targetrb.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}
