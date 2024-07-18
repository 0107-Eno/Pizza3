using UnityEngine;

public class PlayerMovementState : PlayerState
{
    public PlayerMovementState(PlayerStateContext context, PlayerStateMachine.PlayerStates estate) : base(context, estate)
    {
        PlayerStateContext Context = context;
    }
    public override void EnterState()
    {
        Debug.Log("MovementStateäJén");
    }
    public override void ExitState()
    {
        Debug.Log("MovementStateèIóπ");
    }
    public override void UpdateState()
    {
        Debug.Log("MovementStateíÜ");
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
