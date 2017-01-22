using UnityEngine;
using System.Collections;

public class BobVictoryState : BobBaseState, IEnemyState
{
    private int nextWayPoint;

    public BobVictoryState(StatePatternBob statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void OnTriggerEnter(Collider other)
    {
    }

    public void UpdateState()
    {
        Dance();
    }

    private void Dance()
    {
    }
}