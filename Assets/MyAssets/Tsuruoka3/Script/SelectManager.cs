using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    
    //�I����ʂ̏��
    private enum SelectState
    {
        Ready, //����
        PlayerNum, //�v���C�l���I��
        Audio, //�I�[�f�B�I�ݒ�
        Go, //�ݒ芮���A�Q�[����ʂɈړ�����
    }

    private SelectState state;
    [SerializeField] private List<Canvas> canvass; //�Z���N�g��ʃ��X�g
    [SerializeField] private List<Dropdown> dropdowns; //�v���_�E���R���|�[�l���g
    [SerializeField] private List<AudioClip> audioClips; //BGM���X�g
    private int bgmTypeNumber; //BGM�ԍ�

    [SerializeField] private List<GameObject> buttons;
    private EventSystem eventSystem;

    //���L�ϐ�
    public static SelectManager Instance;

    [System.Serializable]
    public struct UserSetting
    {
        public int PlayerNum; // �v���C�l��
        public AudioClip audioClip; // �Đ�����BGM
        public int bgmVolume;
        public int seVolume;
    }
    public UserSetting userSetting;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �Q�[���J�n���� PlayerNum ��ۑ�
    public void SavePlayerNum()
    {
        PlayerPrefs.SetInt("PlayerNum", userSetting.PlayerNum);
    }

    // �Q�[���V�[���� PlayerNum ���擾
    public void LoadPlayerNum()
    {
        userSetting.PlayerNum = PlayerPrefs.GetInt("PlayerNum", 1);  // �f�t�H���g��1
    }


// Start is called before the first frame update
void Start()
    {
        eventSystem = EventSystem.current;

        //�S�ẴZ���N�g��ʂ��\��
        for (int i = 0; i < canvass.Count; i++)
        {
            canvass[i].gameObject.SetActive(false);
        }
        //�����Z���N�g���
        state = SelectState.Ready;

        bgmTypeNumber = 0;
        userSetting.audioClip = audioClips[bgmTypeNumber];
        userSetting.bgmVolume = 3 * 2;
        userSetting.seVolume = 2 * 2;

    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case SelectState.Ready: //����
                canvass[0].gameObject.SetActive(true);
                eventSystem.SetSelectedGameObject(buttons[0]); //�����I��
                break;
            case SelectState.PlayerNum: //�v���C�l���I�����
                canvass[1].gameObject.SetActive(true);
                eventSystem.SetSelectedGameObject(buttons[1]); //�����I��
                userSetting.PlayerNum = dropdowns[0].value + 1;
                break;
            case SelectState.Audio: //�I�[�f�B�I�ݒ�
                canvass[2].gameObject.SetActive(true);
                eventSystem.SetSelectedGameObject(buttons[2]); //�����I��
                bgmTypeNumber = dropdowns[1].value;
                userSetting.audioClip = audioClips[bgmTypeNumber];
                userSetting.bgmVolume = dropdowns[2].value * 2;
                userSetting.seVolume = dropdowns[3].value * 2;

                //�e�ݒ�̈��p��
                AudioDirector._Instance._bgmAudioClip = userSetting.audioClip;
                AudioDirector._Instance._bgmVolume = userSetting.bgmVolume;
                AudioDirector._Instance._seVolume = userSetting.seVolume;
                break;
            case SelectState.Go:
                canvass[3].gameObject.SetActive(true);
                break;
            default:
                break;
        }

        if (Input.GetButtonDown("GamePad_Start"))
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    //OK�{�^��
    public void OnOKButton()
    {
        if (state == SelectState.Ready)
        {
            canvass[0].gameObject.SetActive(false); //��\��
            state = SelectState.PlayerNum; //���̃Z���N�g��ʂɈړ�
        }
        else if (state == SelectState.PlayerNum)
        {
            canvass[1].gameObject.SetActive(false); //��\��
            dropdowns[2].value = 3;
            dropdowns[3].value = 2;
            state = SelectState.Audio; //���̃Z���N�g��ʂɈړ�
        }
        else if (state == SelectState.Audio)
        {
            canvass[2].gameObject.SetActive(false); //��\��
            state = SelectState.Go; //���̃Z���N�g��ʂɈړ�
        }
        else
        {
            canvass[3].gameObject.SetActive(false); //��\��
        }
    }

}
