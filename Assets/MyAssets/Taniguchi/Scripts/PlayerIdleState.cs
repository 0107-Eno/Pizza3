using UnityEngine;

public class PlayerIdleState:PlayerState
{
    public PlayerIdleState(PlayerStateContext context,PlayerStateMachine.PlayerStates estate):base(context, estate)
    {
        PlayerStateContext Context = context;
    }

    /// <summary>
    /// �J�n���ɌĂяo�����֐�
    /// </summary>
    public override void EnterState()
    {
        Debug.Log("IdleState�J�n");
    }
    /// <summary>
    /// State�𔲂���Ƃ��ɌĂяo�����֐�
    /// </summary>
    public override void ExitState()
    {

    }
    /// <summary>
    /// �Ăяo����Ă���ԏ������s���֐�
    /// </summary>
    public override void UpdateState()
    {
        Debug.Log("IdleState��");
    }
    public override PlayerStateMachine.PlayerStates GetNextState()
    {
        return StateKey;
    }
    /// <summary>
    /// �����蔻��(�G�ꂽ��)
    /// </summary>
    /// <param name="other"></param>
    public override void OnTriggerEnter(Collider other)
    {

    }
    /// <summary>
    /// �����蔻��(�G��Ă��)
    /// </summary>
    /// <param name="other"></param>
    public override void OnTriggerStay(Collider other)
    {

    }
    /// <summary>
    /// �����蔻��(��������)
    /// </summary>
    /// <param name="other"></param>
    public override void OnTriggerExit(Collider other)
    {

    }
}
