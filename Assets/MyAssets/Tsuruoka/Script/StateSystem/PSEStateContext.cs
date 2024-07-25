using UnityEngine;

public class PSEStateContext
{
    //PSEStateMachine�ɒǉ��������L�G���A�̂��̂�����
    private AudioSource _as;
    private AudioClip[] _Seclips;

    //----------------------------------------------------------------------------------------------
    //��ŏ��������̂������ƃ��\�b�h���ɏ���
    public PSEStateContext(AudioSource audioSource, AudioClip[] seclips)
    {
        _as = audioSource;
        _Seclips = seclips;
    }

    //----------------------------------------------------------------------------------------------

    //��ŏ��������̂�Ԃ�
    public AudioSource audioSource => _as;
    public AudioClip[] seclips => _Seclips;
}
