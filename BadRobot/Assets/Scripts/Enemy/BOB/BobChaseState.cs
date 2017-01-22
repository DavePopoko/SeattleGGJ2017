using UnityEngine;

public class BobChaseState : BobBaseState, IEnemyState
{
    public BobChaseState(StatePatternBob statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
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