using UnityEngine;

public class BobRangeAttackState : BobBaseState, IEnemyState
{
    public BobRangeAttackState(StatePatternBob statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }
    
    public void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}