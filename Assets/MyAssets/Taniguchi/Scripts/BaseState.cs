using UnityEngine;
using System;

public abstract class BaseState<EState>where EState: Enum
{
    public BaseState(EState key)
    {
        StateKey = key;
    }
    public EState StateKey { get; private set; }
    /// <summary>
    /// �J�n���ɌĂяo�����֐�
    /// </summary>
    public abstract void EnterState();
    /// <summary>
    /// State�𔲂���Ƃ��ɌĂяo�����֐�
    /// </summary>
    public abstract void ExitState();
    /// <summary>
    /// �Ăяo����Ă���ԏ������s���֐�
    /// </summary>
    public abstract void UpdateState();
    public abstract EState GetNextState();
    /// <summary>
    /// �����蔻��(�G�ꂽ��)
    /// </summary>
    /// <param name="other"></param>
    public abstract void OnTriggerEnter(Collider other);
    /// <summary>
    /// �����蔻��(�G��Ă��)
    /// </summary>
    /// <param name="other"></param>
    public abstract void OnTriggerStay(Collider other);
    /// <summary>
    /// �����蔻��(��������)
    /// </summary>
    /// <param name="other"></param>
    public abstract void OnTriggerExit(Collider other);
}
