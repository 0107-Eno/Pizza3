using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBGM : MonoBehaviour
{
    private AudioSource audioSource;

    //BGM����
    [SerializeField]private AudioClip[] bgmClips;

    private string fPath = "Sound/BGM";

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();

        //������ǂݍ���
        InData(fPath);

        //BGM�Đ�
        LoopPlayBack(bgmClips[1]);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //--------------------------------------------------------------------------------------
    //�w�肵���t�H���_���̃f�[�^��z��ɓ����
    private void InData(string s)
    {
        bgmClips = Resources.LoadAll<AudioClip>(s);
    }
    //--------------------------------------------------------------------------------------
    //���[�v�Đ�
    private void LoopPlayBack(AudioClip clip)
    {
        //AudioClip��ݒ肷��
        audioSource.clip = clip;

        //���[�v�Đ���L���ɂ���
        audioSource.loop = true;

        //BGM���Đ�����
        audioSource.Play();
    }
}
