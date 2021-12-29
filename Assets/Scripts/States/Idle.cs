using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Idle(GameObject _npc, UnityEngine.AI.NavMeshAgent _agent, Animator _anim, Transform _player)
        :base (_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {
        //Here we need a Logic condition to stop or continue the state behavior
        if(Random.Range(0, 100) < 10)
        {
            nextState = new Patrol(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        //base.Update();
    }
    public override void Exit()
    {
        //Cleans up the animation event running in the system
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
