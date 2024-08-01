using UnityEngine;

public class EnemySearchState : EnemyState
{
    public EnemySearchState(EnemyStateContext context, EnemyStateMachine.EnemyStates estate) : base(context, estate)
    {
        EnemyStateContext Context = context;
    }


    public override void EnterState()
    {
        Debug.Log("SearchState�J�n");
    }

    public override void ExitState()
    {
        Debug.Log("SearchState�I��");
    }

    public override void UpdateState()
    {
        Debug.Log("SearchState��");
    }
    public override EnemyStateMachine.EnemyStates GetNextState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return EnemyStateMachine.EnemyStates.Movement;
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
