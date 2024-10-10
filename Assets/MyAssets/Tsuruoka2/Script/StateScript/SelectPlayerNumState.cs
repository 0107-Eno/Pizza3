using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static SelectStateMachine;

public class SelectPlayerNumState : SelectState
{
    private GameObject _textObj;
    private Text _text;
    //----------------------------------------------------------------------------------------------
    public SelectPlayerNumState(SelectStateContext context, SelectStateMachine.SelectStates estate) : base(context, estate)
    {
        SelectStateContext Context = context;
    }
    //----------------------------------------------------------------------------------------------
    //�J�n���ɌĂяo�����֐�
    public override void EnterState()
    {
        Debug.Log("PlayerNumState�J�n");
        //�Z���N�g��ʂ�\������
        Context.canvass[Context.canvasNumber].gameObject.SetActive(true);
        _textObj = GameObject.Find("PlayerNumText");
        _text = _textObj.GetComponent<Text>();
    }
    //----------------------------------------------------------------------------------------------
    //State�𔲂���Ƃ��ɌĂяo�����֐�
    public override void ExitState()
    {
        Debug.Log("PlayerNumState�I��");
    }
    //----------------------------------------------------------------------------------------------
    // �Ăяo����Ă���ԏ������s���֐�
    public override void UpdateState()
    {
        Debug.Log("PlayerNumState��");
        _text.text=Context.playerNum.ToString();
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
