using UnityEngine;

public class SkitterChaseState : SkitterBaseState, IEnemyState

{
    //private readonly StatePatternSkitter enemy;

    public SkitterChaseState(StatePatternSkitter statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void OnTriggerEnter(Collider other)
    {
    }

    public override void ToAlertState()
    {
        Debug.Log("Enter ALERT (scanning)");
        enemy.currentState = enemy.alertState;
    }

    //public void ToChaseState()
    //{
    //    Debug.Log("Can't transition to same state");
    //}

    //public void ToMeleeAttackState()
    //{
    //}

    //public void ToPatrolState()
    //{
    //}

    //public void ToRangeAttackState()
    //{
    //}

    //public void ToScanState()
    //{
    //}

    //public void ToVictoryState()
    //{
    //}

    public void UpdateState()
    {
        Look();
        Chase();
    }

    private void Chase()
    {
        enemy.meshRendererFlag.material.color = Color.red;
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
        enemy.navMeshAgent.Resume();
    }

    //private void Look()
    //{
    //    RaycastHit hit;
    //    Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.Scanner.transform.position;
    //    if (Physics.Raycast(enemy.Scanner.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
    //    {
    //        enemy.chaseTarget = hit.transform;
    //    }
    //    else
    //    {
    //        ToAlertState();
    //    }
    //}
}