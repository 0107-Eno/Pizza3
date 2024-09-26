using UnityEngine;

public class PSEStateContext
{
    //PSEStateMachine�ɒǉ��������L�G���A�̂��̂�����
    private AudioSource _as;
    private AudioClip[] _Seclips;
    private PlayerMovementStateMachine _pMovementStateMachine;


    //----------------------------------------------------------------------------------------------
    //��ŏ��������̂������ƃ��\�b�h���ɏ���
    public PSEStateContext(AudioSource audioSource, AudioClip[] seclips, PlayerMovementStateMachine pMovementStateMachine)
    {
        _as = audioSource;
        _Seclips = seclips;
        _pMovementStateMachine = pMovementStateMachine;

    }

    //----------------------------------------------------------------------------------------------

    //��ŏ��������̂�Ԃ�
    public AudioSource audioSource => _as;
    public AudioClip[] seclips => _Seclips;
    public PlayerMovementStateMachine pMovementStateMachine => _pMovementStateMachine; 
}
