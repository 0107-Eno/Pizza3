using UnityEngine;

public class PlayerIdleState:PlayerState
{
    float x, z;
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
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        //Debug.Log("IdleState��");
    }
    public override PlayerStateMachine.PlayerStates GetNextState()
    {
        if (x != 0 || z != 0)
        {
            return PlayerStateMachine.PlayerStates.Movement;
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
