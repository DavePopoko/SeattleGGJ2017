using UnityEngine;

public class SkitterPatrolState : SkitterBaseState, IEnemyState

{
    private int nextWayPoint=0;
    
    public SkitterPatrolState(StatePatternSkitter statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.animator.SetTrigger("IsAttacking");
            Debug.Log("Enter ALERT");
            ToAlertState();
        }
    }
    
    public override void UpdateState()
    {
        if (enemy.enteredstate)
        {
            Debug.Log("Entered Patrol State");
            enemy.animator.SetBool("isRoboMoving", true);
            enemy.animator.SetTrigger("isTaunting");
            enemy.enteredstate = false;
        }
        
        Look();
        Patrol();
    }
    
    private void Patrol()
    {
        //enemy.meshRendererFlag.material.color = Color.green;
        enemy.navMeshAgent.destination = enemy.wayPoints[nextWayPoint].position;
        enemy.navMeshAgent.Resume();

        if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
        }
    }
}