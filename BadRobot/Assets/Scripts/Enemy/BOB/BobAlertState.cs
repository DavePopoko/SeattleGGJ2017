using UnityEngine;

public class BobAlertState : BobBaseState, IEnemyState
{
    public BobAlertState(StatePatternBob statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void ToAlertState()
    {
        Debug.Log("Can't transition to same state");
    }

    public override void UpdateState()
    {
        if (enemy.enteredstate)
        {
            Debug.Log("Entered Alert State");
            enemy.animator.SetBool("isRoboMoving", false);
            enemy.enteredstate = false;
        }
        Look();
        Search();
    }
}