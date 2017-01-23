using UnityEngine;
using System.Collections;

public class DroneVictoryState : DroneBaseState, IEnemyState
{
    private int nextWayPoint;

    public DroneVictoryState(StatePatternDrone statePatternEnemy)
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