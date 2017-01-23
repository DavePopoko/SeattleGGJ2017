using UnityEngine;

public class DroneRangeAttackState : DroneBaseState, IEnemyState
{
    public DroneRangeAttackState(StatePatternDrone statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }
    
    public void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}