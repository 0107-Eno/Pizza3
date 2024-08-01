using UnityEngine;
using UnityEngine.Assertions;

public class PSEStateMachine : StateManager<PSEStateMachine.PSEStates>
{
    /// <summary>
    /// PSEStateMachine�ň���State�̎��
    /// <summary>
    public enum PSEStates
    {
        Idel,
        Movement,
        Jump,
        Dead,
    }

    private PSEStateContext _context;
    private float __volume = 0; //����
    private const string _fPath = "Sound/SE/Player";

    //���L�G���A�@context�ɓ����
    //
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip[] _Seclips; //SE�����z��
    //

    //----------------------------------------------------------------------------------------------
    void Awake()
    {
        //�G���[���b�Z�[�W�\��
        NullMessage();
        //���L�G���A�ɒǉ��������̂������Ɏ�������
        _context = new PSEStateContext(_as, _Seclips);

        InitializeStates();

        //���ʐݒ�
        UpdateVolume();
        //SE�̓ǂݍ���
        InData(ref _Seclips, _fPath);
    }
    //----------------------------------------------------------------------------------------------
    private void NullMessage()
    {
        Assert.IsNotNull(_as, "null�ł�");
    }
    //----------------------------------------------------------------------------------------------
    // PSEStateMachine�Ŏg��State�̏������ƍŏ��ɌĂяo�����State�̎w��
    private void InitializeStates()
    {
        //�ǉ�����State
        States.Add(PSEStates.Idel, new PSEIdelState(_context, PSEStates.Idel));
        States.Add(PSEStates.Movement, new PSEMovementState(_context, PSEStates.Movement));
        States.Add(PSEStates.Jump, new PSEJumpState(_context, PSEStates.Jump));
        States.Add(PSEStates.Dead, new PSEDeadState(_context, PSEStates.Dead));

        //�ŏ��ɌĂяo��State
        CurrentState = States[PSEStates.Idel];
    }
    //----------------------------------------------------------------------------------------------
    //�ǉ����\�b�h�͂����ɏ���
    //----------------------------------------------------------------------------------------------
    //Update()���I�������Ƃ��ɌĂяo�����
    private void LateUpdate()
    {
        UpdateVolume();
    }
    //----------------------------------------------------------------------------------------------
    //���ʂ̍X�V
    public void UpdateVolume()
    {
        float seVolume = AudioManeger._Instance._seVolume;
        //float seVolume = 1;
        if (__volume != seVolume)
        {
            //�ύX����
            __volume = seVolume;
            _as.volume = __volume / 10f;
        }
    }
    //----------------------------------------------------------------------------------------------
    //SE�̓ǂݍ���
    private void InData(ref AudioClip[] audioClips_, string fPath_)
    {
        audioClips_ = Resources.LoadAll<AudioClip>(fPath_);
    }
}
