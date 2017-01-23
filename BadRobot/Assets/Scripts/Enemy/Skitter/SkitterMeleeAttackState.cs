using UnityEngine;

public class SkitterMeleeAttackState : SkitterBaseState, IEnemyState
{
    public SkitterMeleeAttackState(StatePatternSkitter statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public override void UpdateState()
    {
        if (enemy.enteredstate)
        {
            Debug.Log("Entered Melee State");
            enemy.animator.SetBool("isRoboMoving", false);
            enemy.enteredstate = false;
        }

        Look();
        Attack();
    }

    private void Attack()
    {
        float dist = Vector3.Distance(enemy.transform.position, enemy.chaseTarget.position);

        if (dist >= 4.0f)
        {
            ToChaseState();
        }
        enemy.navMeshAgent.Stop();

        // TODO: turn to face
        float angle = 15f;

        var targetPosition = enemy.chaseTarget.position;
        targetPosition.y = enemy.transform.position.y;

        //if (!(Mathf.Abs(Vector3.Angle(enemy.chaseTarget.transform.forward, enemy.transform.position - enemy.chaseTarget.transform.position)) < angle))
        //if (!(Mathf.Abs(Vector3.Angle(targetPosition, enemy.transform.position - targetPosition)) < angle))
        //{
          //  var pp = Mathf.Abs(Vector3.Angle(enemy.transform.position, enemy.transform.position - targetPosition));
            //rotate
            // transform.LookAt(transform.position + new Vector3(0,0,1), target);
            //var targetRotation = Quaternion.LookRotation(enemy.chaseTarget.transform.position - enemy.transform.position);
            //var str = Mathf.Min(0.9f * Time.deltaTime, 1);
            //enemy.transform.rotation = Quaternion.Lerp(enemy.transform.rotation, targetRotation, str);

            //enemy.animator.SetBool("isRoboMoving", true);
            //instant look at - bad 

            //var targetRotation = Quaternion.LookRotation(targetPosition - enemy.transform.position);
            //var str = Mathf.Min(0.9f * Time.deltaTime, 1);
            //enemy.transform.rotation = Quaternion.Lerp(enemy.transform.rotation, targetRotation, str);
            
            //enemy.transform.LookAt(targetPosition);
        //}
        // if not facing 
        // TODO
        //else
        //{
            enemy.animator.SetTrigger("IsAttacking");
            enemy.animator.SetBool("isRoboMoving", false);
        //}
    }
}