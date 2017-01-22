using UnityEngine;

public class SkitterMeleeAttackState : SkitterBaseState, IEnemyState
{
    //private readonly StatePatternSkitter enemy;

    public SkitterMeleeAttackState(StatePatternSkitter statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void ToAlertState()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void ToChaseState()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void ToMeleeAttackState()
    //{
    //    Debug.Log("Can't transition to same state");
    //}

    //public void ToPatrolState()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void ToRangeAttackState()
    //{
    //}

    //public void ToVictoryState()
    //{
    //}

    //public void UpdateState()
    //{
    //    throw new System.NotImplementedException();
    //}

    //// Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}