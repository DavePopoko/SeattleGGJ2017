using UnityEngine;
using System.Collections;

public interface IEnemyState
{

    void OnTriggerEnter(Collider other);

    void ToAlertState();

    void ToChaseState();

    void ToMeleeAttackState();

    void ToPatrolState();

    void ToRangeAttackState();

    void ToVictoryState();

    void UpdateState();
}