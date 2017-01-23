using UnityEngine;

public class OmniRangeAttackState : OmniBaseState, IEnemyState
{
    public OmniRangeAttackState(StatePatternOmni statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }
    
    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}