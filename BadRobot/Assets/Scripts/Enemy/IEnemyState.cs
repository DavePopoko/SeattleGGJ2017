﻿using UnityEngine;
using System.Collections;

public interface IEnemyState
{

    void UpdateState();

    void OnTriggerEnter(Collider other);

    void ToPatrolState();

    void ToAlertState();

    void ToChaseState();

    void ToRangeAttackState();

    void ToMeleeAttackState();
}