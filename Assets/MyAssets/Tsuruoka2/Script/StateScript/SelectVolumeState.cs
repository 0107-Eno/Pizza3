using UnityEngine;
using static SelectStateMachine;

public class SelectVolumeState : SelectState
{
    //----------------------------------------------------------------------------------------------
    public SelectVolumeState(SelectStateContext context, SelectStateMachine.SelectStates estate) : base(context, estate)
    {
        SelectStateContext Context = context;
    }
    //----------------------------------------------------------------------------------------------
    //�J�n���ɌĂяo�����֐�
    public override void EnterState()
    {
        Debug.Log("VolumeState�J�n");
    }
    //----------------------------------------------------------------------------------------------
    //State�𔲂���Ƃ��ɌĂяo�����֐�
    public override void ExitState()
    {
        Debug.Log("VolumeState�I��");
    }
    //----------------------------------------------------------------------------------------------
    // �Ăяo����Ă���ԏ������s���֐�
    public override void UpdateState()
    {
        Debug.Log("VolumeState��");
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
