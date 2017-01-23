using UnityEngine;
using System.Collections;

public class SkitterVictoryState : SkitterBaseState, IEnemyState
{
    private int nextWayPoint;

    public SkitterVictoryState(StatePatternSkitter statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void OnTriggerEnter(Collider other)
    {
    }

    public override void UpdateState()
    {
        Dance();
    }

    private void Dance()
    {
    }
}