using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using static PlayerAnimationStateMachine;

public class PlayerAnimationIdleState : PlayerAnimationState
{
    public PlayerAnimationIdleState(PlayerAnimationStateContext context, PlayerAnimationStateMachine.PlayerAnimationStates estate) : base(context, estate)
    {
        PlayerAnimationStateContext Context = context;
    }
    public override void EnterState()
    {
        Debug.Log("IdleState�J�n");
        Context.animator.SetBool("Idle", true);
    }
    public override void ExitState()
    {
        Debug.Log("IdleState�I��");
    }
    public override void UpdateState()
    {
        Debug.Log("IdleState��");
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

    }
    public override PlayerAnimationStateMachine.PlayerAnimationStates GetNextState()
    {
        return StateKey;
    }
    public override void OnTriggerEnter(Collider other)
    {

    }
    public override void OnTriggerStay(Collider other)
    {

    }
    public override void OnTriggerExit(Collider other)
    {

    }
}
