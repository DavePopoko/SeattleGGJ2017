using UnityEngine;
using System.Collections;

public class OmniVictoryState : OmniBaseState, IEnemyState

{
    //private readonly StatePatternOmni enemy;
    private int nextWayPoint;

    public OmniVictoryState(StatePatternOmni statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void OnTriggerEnter(Collider other)
    {
    }

    public void ToAlertState()
    {
    }

    public void ToChaseState()
    {
    }

    public void ToMeleeAttackState()
    {
    }

    public void ToPatrolState()
    {
    }

    public void ToRangeAttackState()
    {
    }

    public void ToScanState()
    {
    }

    public void ToVictoryState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void UpdateState()
    {
        Dance();
    }

    private void Dance()
    {
    }
}