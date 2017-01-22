using UnityEngine;

public class OmniMeleeAttackState : OmniBaseState, IEnemyState
{
    //private readonly StatePatternOmni enemy;

    public OmniMeleeAttackState(StatePatternOmni statePatternEnemy)
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