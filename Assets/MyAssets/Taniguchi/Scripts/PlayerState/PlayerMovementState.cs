using UnityEngine;

public class PlayerMovementState : PlayerState
{
    public PlayerMovementState(PlayerStateContext context, PlayerStateMachine.PlayerStates estate) : base(context, estate)
    {
        PlayerStateContext Context = context;
    }
    public override void EnterState()
    {
        
        Debug.Log("MovementState開始");
    }

    public override void ExitState()
    {
        Debug.Log("MovementState終了");
    }

    public override void UpdateState()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Context.myTransform.position += new Vector3(x, 0, z) * Context.pspeed * Time.deltaTime;
        Debug.Log("MovementState中");
    }
    public override PlayerStateMachine.PlayerStates GetNextState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return PlayerStateMachine.PlayerStates.Dead;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {
        Rigidbody _other = other.GetComponent<Rigidbody>();
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("当たった");
            _other.AddForce(new Vector3(0, 10, 0));
        }
        
    }

    public override void OnTriggerStay(Collider other)
    {

    }

    public override void OnTriggerExit(Collider other)
    {

    }
}
