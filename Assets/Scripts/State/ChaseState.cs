using Unity.VisualScripting;

public class ChaseState : IState
{
    private AIController aIController;

    public StateType Type => StateType.Chase;

    public ChaseState(AIController aiController){
        this.aIController = aiController;
    }


    public void Enter(){
        aIController.Animator.SetBool("isChasing", true);
    }

    public void Execute(){
        if(!aIController.CanSeePlayer()){
            aIController.StateMachine.TransitionToState(StateType.Patrol);
            return;
        }

        if(aIController.IsPlayerInAttackRange()){
            aIController.StateMachine.TransitionToState(StateType.Attack);
            return;
        }

        aIController.Agent.destination = aIController.Player.position;


    }

    public void Exit(){

    }

    


}
