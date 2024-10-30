using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirector : MonoBehaviour
{
    //�V���O���g���̃C���X�^���X
    private static AudioDirector _instance;
    public static AudioDirector _Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioDirector>();
                if (_instance == null)
                {
                    GameObject _obj = new GameObject("AudioDirector");
                    _instance = _obj.AddComponent<AudioDirector>();
                    DontDestroyOnLoad(_obj);
                }
            }
            
            return _instance;
        }
    }

    //�I�[�f�B�I�R���|�l���g�@BGM
    private AudioSource _audioSource;
    //�I�[�f�B�I�R���|�l���g�@SE
    [SerializeField] private GameObject _audioSEObj;
    private AudioSource _audioSourceSE;

    [SerializeField] private AudioClip _seAudioClip;
    public AudioClip _bgmAudioClip;

    //BGM�̉���
    public float _bgmVolume = 6;
    //SE�̉��ʁ@�S�Ẵv���C�����Q�Ƃ���
    public float _seVolume = 4;
    //bgm�ԍ�
    //[HideInInspector] public int _bgmNumber = 0;


    //�X�^�[�g����������������
    private void Awake()
    {

        //�V���O���g���̃C���X�^���X��ݒ�
        if (_instance == null)
        {
            //Debug.Log("AudioDirector instance is null, setting this instance.");
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != null)
        {
            //Debug.Log("AudioDirector instance already exists, destroying this instance.");
            Destroy(gameObject);
            //return;
        }

        //�I�[�f�B�I�\�[�X�̏�����
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (_audioSEObj != null)
        {
            _audioSourceSE = _audioSEObj.GetComponent<AudioSource>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�l���g�擾
        _audioSource = GetComponent<AudioSource>();
        //���ʐݒ�
        _audioSource.volume = _bgmVolume / 10;
        _audioSourceSE.volume = _seVolume / 10;
        //����BGM
        LoopPlayBack(_bgmAudioClip);
    }

    // Update is called once per frame
    void Update()
    {
        AudioUpdate(_bgmAudioClip);
        _audioSource.volume = _bgmVolume / 10;
        _audioSourceSE.volume = _seVolume / 10;
    }
    //--------------------------------------------------------------------------------------
    //�w�肵�����������[�v�Đ�������
    public void LoopPlayBack(AudioClip clip)
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
    public void AudioUpdate(AudioClip clip_)
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
    //SE���ʊm�F�{�^��
    public void SETestButton()
    {
        _audioSourceSE.PlayOneShot(_seAudioClip);
    }
}
