using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class AudioBGM : MonoBehaviour
{
    private AudioSource audioSource;

    //�t�@�C���p�X
    private const string fPath = "Sound/BGM";

    //BGM�����z��
    [SerializeField] private AudioClip[] bgmClips;
    //�����ԍ��@�����Ɩ��O����
    private int bgmNumber;
    //�����̖��O�z��
    [SerializeField] private string[] bgmName;

    //BGM�̉���
    [SerializeField]private float bgmVolume;

    //BFMType�̃e�L�X�g
    [SerializeField] private TextMeshProUGUI bgmTypeText;
    //bgm�̉��ʂ̃e�L�X�g
    [SerializeField] private TextMeshProUGUI bgmVolumeText;

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();

        //���������ݒ�
        bgmNumber = 0;
        //�������ʐݒ�
        bgmVolume = 5;
       
        //������z��ɓǂݍ���
        InData(ref bgmClips, fPath);

        //���O�z��̐���
        bgmName = new string[bgmClips.Length];
        //�����̖��O��z��ɓǂݍ���
        for (int i = 0; i < bgmClips.Length; i++)
        {
            bgmName[i] = CutString(bgmClips[i].ToString(), ' ');
        }

        //BGM�Đ�
        LoopPlayBack(bgmClips[bgmNumber]);
    }

    // Update is called once per frame
    void Update()
    {
        //�����̍X�V
        AudioUpdate(bgmClips[bgmNumber]);
        //���ʐݒ�
        audioSource.volume = (bgmVolume/10);

        //Text�\��
        bgmVolumeText.text = bgmVolume.ToString();
        bgmTypeText.text = bgmName[bgmNumber];
    }
    //--------------------------------------------------------------------------------------
    //�w�肵���t�H���_���̃f�[�^��z��ɓ����
    private void InData(ref AudioClip[] audioClips_, string fPath_)
    {
        audioClips_ = Resources.LoadAll<AudioClip>(fPath_);
    }
    //--------------------------------------------------------------------------------------
    //�w�肵�����������[�v�Đ�������
    private void LoopPlayBack(AudioClip clip)
    {
        //AudioClip��ݒ肷��
        audioSource.clip = clip;

        //���[�v�Đ���L���ɂ���
        audioSource.loop = true;

        //BGM���Đ�����
        audioSource.Play();
    }
    //--------------------------------------------------------------------------------------
    //�����̍X�V
    private void AudioUpdate(AudioClip clip_)
    {
        //�ǂ̉������Đ�����Ă��邩�R�s�[
        AudioClip audioClipCopy = audioSource.clip;

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
    //�v���X�{�^���@BGM����
    public void VolumePlusButton()
    {
        if (bgmVolume == 10)
        {
            //�����������v���X���Ȃ�
            return;
        }
        bgmVolume++;
    }
    //--------------------------------------------------------------------------------------
    //�v���X�{�^���@BGMType
    public void TypePlusButton()
    {
        if (bgmNumber == bgmClips.Length - 1)
        {
            //�����������v���X���Ȃ�
            return;
        }
        bgmNumber++;
    }
    //--------------------------------------------------------------------------------------
    //�}�C�i�X�{�^���@BGM����
    public void VolumeMinusButton()
    {
        if (bgmVolume == 0)
        {
            //������������v���X���Ȃ�
            return;
        }
        bgmVolume--;
    }
    //--------------------------------------------------------------------------------------
    //�}�C�i�X�{�^���@BGMTypr
    public void TypeMinusButton()
    {
        if (bgmNumber == 0)
        {
            //������������v���X���Ȃ�
            return;
        }
        bgmNumber--;
    }
}
