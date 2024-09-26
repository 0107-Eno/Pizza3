using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static PSEStateMachine;

public class SelectStateMachine : StateManager<SelectStateMachine.SelectStates>
{
    /// <summary>
    /// SelectStateMachine�ň���State�̎��
    /// <summary>
    public enum SelectStates
    {
        None,
        PlayerNum,   //�v���C�l��
        PlayerModel, //���삷��L�����N�^
        BGMType,     //BGM�̎��
        Volume,      //����
    }

    private SelectStateContext _context;

    //���L�G���A�@context�ɓ����
    //
    private int _canvasNumber = 0; //�Z���N�g��ʔԍ�
    private int _playerNum = 1; //�v���C�l��
    private int _playerModel = 0; //�L�����N�^���f���ԍ�
    private int _bgmType = 0; //BGM�ԍ�
    private int _bgmVolume = 10; //BGM����
    private int _seVolume = 10; //SE����
    [SerializeField] private List<Canvas> _canvass; //�Z���N�g��ʂ�canvas
    //

    //----------------------------------------------------------------------------------------------
    void Awake()
    {
        //�G���[���b�Z�[�W�\��
        NullMessage();
        //���L�G���A�ɒǉ��������̂������Ɏ�������
        _context = new SelectStateContext(_canvasNumber, _playerNum, _playerModel, _bgmType, _bgmVolume, _seVolume, _canvass);

        InitializeStates();

    }
    //----------------------------------------------------------------------------------------------
    private void NullMessage()
    {
        Assert.IsNotNull("null�ł�");
    }
    //----------------------------------------------------------------------------------------------
    // SelectStateMachine�Ŏg��State�̏������ƍŏ��ɌĂяo�����State�̎w��
    private void InitializeStates()
    {
        //�S�ẴZ���N�g��ʂ��\���ɂ���
        for (int i = 0; i < _canvass.Count; i++)
        {
            _canvass[i].gameObject.SetActive(false);
        }
        //�ǉ�����State
        States.Add(SelectStates.None, new SelectNoneState(_context, SelectStates.None));
        States.Add(SelectStates.PlayerNum, new SelectPlayerNumState(_context, SelectStates.PlayerNum));
        States.Add(SelectStates.PlayerModel, new SelectPlayerModelState(_context, SelectStates.PlayerModel));
        States.Add(SelectStates.BGMType, new SelectBGMTypeState(_context, SelectStates.BGMType));
        States.Add(SelectStates.Volume, new SelectVolumeState(_context, SelectStates.Volume));
        //�ŏ��ɌĂяo��State
        CurrentState = States[SelectStates.None];
    }
    //----------------------------------------------------------------------------------------------
    //�ǉ����\�b�h�͂����ɏ���
    //----------------------------------------------------------------------------------------------

}
