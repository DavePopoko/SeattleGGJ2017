using UnityEngine;
using System.Collections;

public class OmniVictoryState : OmniBaseState, IEnemyState
{
    private int nextWayPoint;

    public OmniVictoryState(StatePatternOmni statePatternEnemy)
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