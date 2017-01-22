using UnityEngine;

public class DroneAlertState : IEnemyState

{
    private readonly StatePatternDrone enemy;
    private float searchTimer;

    public DroneAlertState(StatePatternDrone statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void OnTriggerEnter(Collider other)
    {
    }

    public void ToAlertState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToChaseState()
    {
        Debug.Log("Enter CHASE");
        enemy.currentState = enemy.chaseState;
        searchTimer = 0f;
    }

    public void ToMeleeAttackState()
    {
    }

    public void ToPatrolState()
    {
        Debug.Log("Enter Patrol");
        enemy.currentState = enemy.patrolState;
        searchTimer = 0f;
    }

    public void ToRangeAttackState()
    {
    }

    public void ToScanState()
    {
    }

    public void ToVictoryState()
    {
    }

    public void UpdateState()
    {
        Look();
        Search();
    }

    private void Look()
    {
        RaycastHit hit;

        Vector3 scanangle = new Vector3();
        //Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.localEulerAngles, out hit, enemy.sightRange);

        if (Physics.Raycast(enemy.Scanner.transform.position, enemy.Scanner.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }
    }

    private void Search()
    {
        Debug.Log("Scanning for player");
        enemy.meshRendererFlag.material.color = Color.yellow;
        enemy.navMeshAgent.Stop();

        //Spin till you find the player
        enemy.transform.Rotate(0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
        searchTimer += Time.deltaTime;

        if (searchTimer >= enemy.searchingDuration)
        {
            ToPatrolState();
        }
    }
}