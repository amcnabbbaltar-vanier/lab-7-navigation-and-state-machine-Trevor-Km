using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class IdleState : IState
{
   private AIController aiController;
   private float idleDuration = 2f;
   private float idleTimer;

   public StateType Type => StateType.Idle;

    public IdleState(AIController aIController){
        this.aiController = aIController;
    }

    public void Enter(){
        idleTimer = 0f;
    }


    public void Execute(){
        idleTimer += Time.deltaTime;
        if(idleTimer >= idleDuration){
            aiController.StateMachine.TransitionToState(StateType.Patrol);
        }
    }

    public void Exit()
{
    
}
   
}

