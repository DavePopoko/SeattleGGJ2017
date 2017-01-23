using UnityEngine;

public class OmniDefeatState : OmniBaseState, IEnemyState
{
    public OmniDefeatState(StatePatternOmni statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void ToDefeatState()
    {
        Debug.Log("Can't transition to same state");
    }

    public override void UpdateState()
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