using System.Collections;
using System.Collections.Generic;
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

    private CharacterController _characterController;
    private Vector3 _velocity;
    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
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
