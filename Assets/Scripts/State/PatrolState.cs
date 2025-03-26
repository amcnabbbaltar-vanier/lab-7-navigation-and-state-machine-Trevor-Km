using UnityEngine.Scripting.APIUpdating;

public class PatrolState : IState
{
   private AIController aiController;
   private int currentWaypointIndex;

   public StateType Type => StateType.Patrol;

   public PatrolState(AIController aIController){
     this.aiController = aIController;
   }

   public void Enter(){
    MoveToNextWaypoint();
   }

    public void Execute(){
        if(aiController.CanSeePlayer()){
            aiController.StateMachine.TransitionToState(StateType.Chase);
            return;
        }

        if(!aiController.Agent.pathPending && aiController.Agent.remainingDistance <= aiController.Agent.stoppingDistance){
            MoveToNextWaypoint();
        }

    }

    public void Exit(){

    }


    private void MoveToNextWaypoint(){
        if(aiController.Waypoints.Length == 0){
            return;
        }
        aiController.Agent.destination = aiController.Waypoints[currentWaypointIndex].position;
        currentWaypointIndex = (currentWaypointIndex + 1) % aiController.Waypoints.Length;
    }



}
