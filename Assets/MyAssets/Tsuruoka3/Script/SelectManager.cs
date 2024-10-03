using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    //�I����ʂ̏��
    private enum SelectState
    {
        PlayerNum, //�v���C�l���I��
        Audio, //�I�[�f�B�I�ݒ�

    }

    private SelectState state;
    [SerializeField] private List<Dropdown> dropdowns; //�v���_�E���R���|�[�l���g
    [SerializeField] private List<AudioClip> audioClips; //BGM���X�g
    private int bgmTypeNumber;

    //���L�ϐ�
    public int PlayerNum; //�v���C�l��
    public AudioClip audioClip; //�Đ�����BGM
    public int bgmVolume;
    public int seVolume;

    // Start is called before the first frame update
    void Start()
    {
        state = SelectState.PlayerNum;
        audioClip = audioClips[0];
        bgmVolume = 6;
        seVolume = 6;
        bgmTypeNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case SelectState.PlayerNum: //�v���C�l���I�����
                PlayerNum = dropdowns[0].value + 1;
                break;
            case SelectState.Audio: //�I�[�f�B�I�ݒ�
                bgmTypeNumber = dropdowns[1].value;
                audioClip = audioClips[bgmTypeNumber];
                break;
            default:
                break;
        }
    }
}
