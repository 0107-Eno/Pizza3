using UnityEngine;

public class EnemyDeadState : EnemyState
{
    public EnemyDeadState(EnemyStateContext context, EnemyStateMachine.EnemyStates estate) : base(context, estate)
    {
        EnemyStateContext Context = context;
    }


    public override void EnterState()
    {
        Debug.Log("DeadState�J�n");
    }

    public override void ExitState()
    {
        Debug.Log("DeadState�I��");
    }

    public override void UpdateState()
    {
        Debug.Log("DeadState��");
    }
    public override EnemyStateMachine.EnemyStates GetNextState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return EnemyStateMachine.EnemyStates.Search;
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