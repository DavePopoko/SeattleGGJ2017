using UnityEngine;

public class DroneChaseState : DroneBaseState, IEnemyState
{
    public DroneChaseState(StatePatternDrone statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public override void UpdateState()
    {
        if (enemy.enteredstate)
        {
            Debug.Log("Entered Chase State");
            enemy.animator.SetTrigger("isTaunting");
            enemy.animator.SetBool("isRoboMoving", true);
            enemy.enteredstate = false;
        }

        Look();
        Chase();
    }

    private void Chase()
    {
        float dist = Vector3.Distance(enemy.transform.position, enemy.chaseTarget.position);

        if (dist >= 4.0f)
        {
            //Persue
            enemy.navMeshAgent.destination = enemy.chaseTarget.position;
            enemy.navMeshAgent.Resume();
            enemy.animator.SetBool("isRoboMoving", true);
        }
        else
        {
            // Melee  - state transition
            ToMeleeAttackState();
        }
    }
}