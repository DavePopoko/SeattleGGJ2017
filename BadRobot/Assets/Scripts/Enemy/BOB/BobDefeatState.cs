using UnityEngine;

public class BobDefeatState : BobBaseState, IEnemyState
{
    public BobDefeatState(StatePatternBob statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void ToDefeatState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void UpdateState()
    {
        if (enemy.enteredstate)
        {
            Debug.Log("Entered Defeat State");
            enemy.animator.SetBool("isRoboMoving", false);
            enemy.enteredstate = false;
        }
        Look();
        Search();
    }
}