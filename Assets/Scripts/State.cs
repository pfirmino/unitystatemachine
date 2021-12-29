using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Finite State machine (FSM) are sets of STATES that controls game objects
// using predefined behaviors and working in conjunction with Animator Class 
// states and transitions using its EVENT system, which are three:
// - ENTER
// - UPDATE
// - EXIT

public class State
{
    //State Labels for the Logic
    public enum STATE
    {
        IDLE, WALK, RUN, PATROL, PURSUE, ATTACK, HIT, DIE
    }

    //Events for the animator system
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    }

    //Basic properties for contructor
    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected NavMeshAgent agent;
    protected Animator anim;
    protected Transform player;
    public State nextState;

    //Properties for Logic Calculations
    float visDist = 10.0f;
    float visAngle = 30.0f;
    float shootDist = 7.0f;

    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        player = _player;
        stage = EVENT.ENTER;
    }

    //Methods to update the stage event
    //VIRTUAL Keyord Replaces derived method with custom declarations
    public virtual void Enter(){ stage = EVENT.UPDATE; }
    public virtual void Update(){ stage = EVENT.UPDATE; }
    public virtual void Exit(){ stage = EVENT.EXIT; }


    //The method for processing the event system
    public State Process(){
        if(stage == EVENT.ENTER) Enter();
        if(stage == EVENT.UPDATE) Update();
        if(stage == EVENT.EXIT){
            Exit();
            return nextState;
        }
        return this;
    }
}
