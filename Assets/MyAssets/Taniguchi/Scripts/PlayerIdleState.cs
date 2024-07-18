using UnityEngine;
using static PlayerStateMachine;

public class PlayerIdleState:PlayerState
{
    public PlayerIdleState(PlayerStateContext context,PlayerStateMachine.PlayerStates estate):base(context, estate)
    {
        PlayerStateContext Context = context;
    }
    public override void EnterState()
    {
        Debug.Log("IdleState�J�n");
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
