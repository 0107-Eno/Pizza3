using UnityEngine;

public class PlayerMovementState : PlayerState
{
    public PlayerMovementState(PlayerStateContext context, PlayerStateMachine.PlayerStates estate) : base(context, estate)
    {
        PlayerStateContext Context = context;
    }
    public override void EnterState()
    {
        Debug.Log("MovementState�J�n");
    }
    public override void ExitState()
    {
        Debug.Log("MovementState�I��");
    }
    public override void UpdateState()
    {
        Debug.Log("MovementState��");
    }
    public override PlayerStateMachine.PlayerStates GetNextState()
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
