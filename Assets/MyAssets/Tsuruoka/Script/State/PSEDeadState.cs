using UnityEngine;
using static PSEStateMachine;

public class PSEDeadState : PSEState
{
    //----------------------------------------------------------------------------------------------
    public PSEDeadState(PSEStateContext context, PSEStateMachine.PSEStates estate) : base(context, estate)
    {
        PSEStateContext Context = context;
    }
    //----------------------------------------------------------------------------------------------
    //�J�n���ɌĂяo�����֐�
    public override void EnterState()
    {
        Debug.Log("NoneState�J�n");
    }
    //----------------------------------------------------------------------------------------------
    //State�𔲂���Ƃ��ɌĂяo�����֐�
    public override void ExitState()
    {
        Debug.Log("NoneState�I��");
    }
    //----------------------------------------------------------------------------------------------
    // �Ăяo����Ă���ԏ������s���֐�
    public override void UpdateState()
    {
        Debug.Log("NoneState��");
        if(Input.GetKeyDown(KeyCode.Z))
        {
            GetNextState();
        }
    }
    //----------------------------------------------------------------------------------------------
    //
    public override PSEStateMachine.PSEStates GetNextState()
    {
        return StateKey;
    }
    //----------------------------------------------------------------------------------------------
    //�����蔻��(�G�ꂽ��)
    public override void OnTriggerEnter(Collider other)
    {

    }
    //----------------------------------------------------------------------------------------------
    //�����蔻��(�G��Ă��)
    public override void OnTriggerStay(Collider other)
    {

    }
    //----------------------------------------------------------------------------------------------
    //�����蔻��(��������)
    public override void OnTriggerExit(Collider other)
    {

    }
}
