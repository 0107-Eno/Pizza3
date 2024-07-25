﻿using UnityEngine;
using static PSEStateMachine;

public class PSEFallState : PSEState
{
    //----------------------------------------------------------------------------------------------
    public PSEFallState(PSEStateContext context, PSEStateMachine.PSEStates estate) : base(context, estate)
    {
        PSEStateContext Context = context;
    }
    //----------------------------------------------------------------------------------------------
    //開始時に呼び出される関数
    public override void EnterState()
    {
        Debug.Log("FallState開始");
    }
    //----------------------------------------------------------------------------------------------
    //Stateを抜けるときに呼び出される関数
    public override void ExitState()
    {
        Debug.Log("FallState終了");
    }
    //----------------------------------------------------------------------------------------------
    // 呼び出されている間処理を行う関数
    public override void UpdateState()
    {
        Debug.Log("FallState中");
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

    }
    //----------------------------------------------------------------------------------------------
    //State遷移
    public override PSEStateMachine.PSEStates GetNextState()
    {
        return StateKey;
    }
    //----------------------------------------------------------------------------------------------
    //当たり判定(触れたら)
    public override void OnTriggerEnter(Collider other)
    {

    }
    //----------------------------------------------------------------------------------------------
    //当たり判定(触れてる間)
    public override void OnTriggerStay(Collider other)
    {

    }
    //----------------------------------------------------------------------------------------------
    //当たり判定(抜けたら)
    public override void OnTriggerExit(Collider other)
    {

    }
}
