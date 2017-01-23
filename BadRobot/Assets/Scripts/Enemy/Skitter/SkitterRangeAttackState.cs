using UnityEngine;

public class SkitterRangeAttackState : SkitterBaseState, IEnemyState
{
    public SkitterRangeAttackState(StatePatternSkitter statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }
    
    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}