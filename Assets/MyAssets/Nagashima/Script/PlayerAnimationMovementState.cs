using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using static PlayerAnimationStateMachine;

public class PlayerAnimationMovementState : PlayerAnimationState
{
    public PlayerAnimationMovementState(PlayerAnimationStateContext context, PlayerAnimationStateMachine.PlayerAnimationStates estate) : base(context, estate)
    {
        PlayerAnimationStateContext Context = context;
    }
    public override void EnterState()
    {
        Debug.Log("MovementState�J�n");
        Context.animator.SetBool("Walk", true);
    }
    public override void ExitState()
    {
        Debug.Log("MovementState�I��");
        Context.animator.SetBool("Walk", false);
    }
    public override void UpdateState()
    {
        Debug.Log("MovementState��");
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        GetNextState();
    }
    public override PlayerAnimationStateMachine.PlayerAnimationStates GetNextState()
    {
        if (Context.pm._currentState == PlayerMovementStateMachine.StateType.Idle)
        {
            return PlayerAnimationStates.Idle;
        }
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
