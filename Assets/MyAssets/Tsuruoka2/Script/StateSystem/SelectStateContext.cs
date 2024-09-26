using System.Collections.Generic;
using UnityEngine;

public class SelectStateContext
{
    //SelectStateMachine�ɒǉ��������L�G���A�̂��̂�����
    private int _canvasNumber = 0; //�Z���N�g��ʔԍ�
    private int _playerNum; //�v���C�l��
    private int _playerModel; //�L�����N�^���f���ԍ�
    private int _bgmType; //BGM�ԍ�
    private int _bgmVolume; //BGM����
    private int _seVolume; //SE����
    private List<Canvas> _canvass; //�Z���N�g��ʂ�canvas
    //----------------------------------------------------------------------------------------------
    //��ŏ��������̂������ƃ��\�b�h���ɏ���
    public SelectStateContext(int canvasNumber, int playerNum, int playerModel, int bgmType, int bgmVolume, int seVolume, List<Canvas> canvass)
    {
        _canvasNumber = canvasNumber;
        _playerNum = playerNum;
        _playerModel = playerModel;
        _bgmType = bgmType;
        _bgmVolume = bgmVolume;
        _seVolume = seVolume;
        _canvass = canvass;
    }

    //----------------------------------------------------------------------------------------------
    //��ŏ��������̂�Ԃ�
    public int canvasNumber => _canvasNumber;
    public int playerNum => _playerNum;
    public int playerModel => _playerModel;
    public int bgmType => _bgmType;
    public int bgmVolume => _bgmVolume;
    public int seVolume => _seVolume;
    public List<Canvas> canvass => _canvass;

}
