using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class AudioManeger : MonoBehaviour
{
    //�V���O���g���̃C���X�^���X
    private static AudioManeger _instance;
    public static AudioManeger _Instance
    {
        get
        {
            if(_instance == null)
            {
                //�I�[�f�B�I�}�l�[�W���[�����݂��Ȃ��ꍇ�͐V�����쐬
                GameObject _obj = new GameObject("AudioManeger");
                _instance = _obj.AddComponent<AudioManeger>();
                DontDestroyOnLoad(_obj);
            }
            return _instance;
        }
    }

    //�I�[�f�B�I�R���|�l���g
    private AudioSource _audioSource;

    //�X�^�[�g����������������
    private void Awake()
    {

        //�V���O���g���̃C���X�^���X��ݒ�
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad (gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //�I�[�f�B�I�\�[�X�̏�����
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    //�t�@�C���p�X�@BGM
    private const string _fPath = "Sound/BGM";

    //BGM�����z��
    [SerializeField] private AudioClip[] _bgmClips;
    //BGM�̖��O������z��
    [SerializeField] private string[] _bgmName;
    //�z��ԍ��@BGM�z��Ɩ��O�z��ŋ���
    private int _bgmNumber;

    //BGM�̉���
    private float _bgmVolume;
    //SE�̉��ʁ@�S�Ẵv���C�����Q�Ƃ���
    public float _seVolume;

    //BGM�̎�ނ�\������Text
    [SerializeField] private TextMeshProUGUI _bgmTypeText;
    //BGM�̉��ʂ�\������Text
    [SerializeField] private TextMeshProUGUI _bgmVolumeText;
    //SE�̉��ʂ�\������Text
    [SerializeField] private TextMeshProUGUI _seVolumeText;

    //�C�x���g�V�X�e��
    private EventSystem _eventSystem;
    //�T�E���h�ݒ�UI�@Canvas
    [SerializeField] private Canvas _audioSettingCanvas;
    //�T�E���h�ݒ�UI�ōŏ��ɑI������Ă���{�^��
    [SerializeField] private GameObject _firstB;

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�l���g�擾
        _audioSource = GetComponent<AudioSource>();
        //�C�x���g�V�X�e���̃C���X�^���X����
        _eventSystem = EventSystem.current;

        //�T�E���h�ݒ�UI���\���ɂ���
        _audioSettingCanvas.enabled = false;
        //�ŏ��ɍĐ������BGM�̐ݒ�
        _bgmNumber = 0;
        //���ʐݒ�
        _bgmVolume = 5;
        _seVolume = 5;

        //BGM�z��̐ݒ�
        InData(ref  _bgmClips, _fPath);
        //���O�z��̐ݒ�
        _bgmName = new string[_bgmClips.Length];
        for (int i = 0; i < _bgmClips.Length; i++)
        {
            _bgmName[i] = CutString(_bgmClips[i].ToString(), ' ');
        }

        //BGM�Đ�
        LoopPlayBack(_bgmClips[_bgmNumber]);
    }

    // Update is called once per frame
    void Update()
    {
        //BGM�̍X�V
        AudioUpdate(_bgmClips[_bgmNumber]);
        //BGM�̉��ʐݒ�
        _audioSource.volume = (_bgmVolume / 10);

        //Text�\��
        _bgmVolumeText.text = _bgmVolume.ToString();
        _bgmTypeText.text = _bgmName[_bgmNumber];

        //����m�F�̂��߂̏���
        //��ŕK������
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                OpenUI();
            }
        }
        //
    }
    //--------------------------------------------------------------
    //�w�肵���t�H���_���̉�����z��ɓ����
    private void InData(ref AudioClip[] audioClips_, string fPath_)
    {
        audioClips_ = Resources.LoadAll<AudioClip>(fPath_);
    }
    //--------------------------------------------------------------------------------------
    //�w�肵�����������[�v�Đ�������
    private void LoopPlayBack(AudioClip clip)
    {
        //AudioClip��ݒ肷��
        _audioSource.clip = clip;

        //���[�v�Đ���L���ɂ���
        _audioSource.loop = true;

        //BGM���Đ�����
        _audioSource.Play();
    }
    //--------------------------------------------------------------------------------------
    //�����̍X�V
    private void AudioUpdate(AudioClip clip_)
    {
        //�ǂ̉������Đ�����Ă��邩�R�s�[
        AudioClip audioClipCopy = _audioSource.clip;

        if (audioClipCopy == clip_)
        {
            return;
        }
        else
        {
            LoopPlayBack(clip_);
        }
    }
    //--------------------------------------------------------------------------------------
    //����̕����ŋ�؂�
    private string CutString(string s_, char delimiter_)
    {
        //���̕�������R�s�[
        string subString = s_;
        // ����̕����̈ʒu������
        int delimiterIndex = subString.IndexOf(delimiter_);
        // ����̕������O�̕�����������擾
        subString = subString.Substring(0, delimiterIndex);
        return subString;
    }
    //--------------------------------------------------------------------------------------
    //�T�E���h�ݒ�UI���J��
    public void OpenUI()
    {
        //�\��
        _audioSettingCanvas.enabled = true;
        //�����{�^���̐ݒ�
        _eventSystem.SetSelectedGameObject(_firstB);
    }
    //--------------------------------------------------------------------------------------
    //����{�^��
    public void CloseButton()
    {
        //�T�E���h�ݒ�UI�����
        _audioSettingCanvas.enabled = false;
    }
    //--------------------------------------------------------------------------------------
    //�v���X�{�^���@BGM����
    public void BGMVolumePlusButton()
    {
        if (_bgmVolume == 10)
        {
            //�����������v���X���Ȃ�
            return;
        }
        _bgmVolume++;
    }
    //--------------------------------------------------------------------------------------
    //�v���X�{�^���@SE����
    public void SEVolumePlusButton()
    {
        if (_seVolume == 10)
        {
            //�����������v���X���Ȃ�
            return;
        }
        _seVolume++;
    }
    //--------------------------------------------------------------------------------------
    //�v���X�{�^���@BGMType
    public void BGMTypePlusButton()
    {
        if (_bgmNumber == _bgmClips.Length - 1)
        {
            //�����������O�ɂ���@�I���������[�v�����邽��
            _bgmNumber = 0;
            return;
        }
        _bgmNumber++;
    }
    //--------------------------------------------------------------------------------------
    //�}�C�i�X�{�^���@BGM����
    public void BGMVolumeMinusButton()
    {
        if (_bgmVolume == 0)
        {
            //������������v���X���Ȃ�
            return;
        }
        _bgmVolume--;
    }
    //--------------------------------------------------------------------------------------
    //�}�C�i�X�{�^���@SE����
    public void SEVolumeMinusButton()
    {
        if (_seVolume == 0)
        {
            //������������v���X���Ȃ�
            return;
        }
        _seVolume--;
    }
    //--------------------------------------------------------------------------------------
    //�}�C�i�X�{�^���@BGMType
    public void BGMTypeMinusButton()
    {
        if (_bgmNumber == 0)
        {
            //������������BGM�z��̍Ō���̔ԍ�������@�I���������[�v�����邽��
            _bgmNumber = _bgmClips.Length - 1;
            return;
        }
        _bgmNumber--;
    }
}
