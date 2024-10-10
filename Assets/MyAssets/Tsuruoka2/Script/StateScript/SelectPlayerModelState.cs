using UnityEngine;
using static SelectStateMachine;

public class SelectPlayerModelState : SelectState
{
    //----------------------------------------------------------------------------------------------
    public SelectPlayerModelState(SelectStateContext context, SelectStateMachine.SelectStates estate) : base(context, estate)
    {
        SelectStateContext Context = context;
    }
    //----------------------------------------------------------------------------------------------
    //�J�n���ɌĂяo�����֐�
    public override void EnterState()
    {
        Debug.Log("PlayerModelState�J�n");
    }
    //----------------------------------------------------------------------------------------------
    //State�𔲂���Ƃ��ɌĂяo�����֐�
    public override void ExitState()
    {
        Debug.Log("PlayerModelState�I��");
    }
    //----------------------------------------------------------------------------------------------
    // �Ăяo����Ă���ԏ������s���֐�
    public override void UpdateState()
    {
        Debug.Log("PlayerModelState��");
        GetNextState();

    }
    //----------------------------------------------------------------------------------------------
    //
    public override SelectStateMachine.SelectStates GetNextState()
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
