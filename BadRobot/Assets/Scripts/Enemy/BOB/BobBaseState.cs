using UnityEngine;

public class BobBaseState : IEnemyState

{
    internal StatePatternBob enemy;
    internal float searchTimer;
    
    public BobBaseState()
    {
    }

    public BobBaseState(StatePatternBob statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
    }

    public virtual void ToAlertState()
    {
        Debug.Log("Enter ALERT");
        enemy.enteredstate = true;
        enemy.currentState = enemy.alertState;
    }


    public virtual void ToChaseState()
    {
        Debug.Log("Enter Chase");
        enemy.enteredstate = true;
        enemy.currentState = enemy.chaseState;
    }

    public virtual void ToMeleeAttackState()
    {
        Debug.Log("Enter Melee");
        enemy.enteredstate = true;
        enemy.currentState = enemy.meleeState;
    }

    public virtual void ToPatrolState()
    {
    }

    public virtual void ToRangeAttackState()
    {
    }

    public virtual void ToScanState()
    {
    }

    public virtual void ToVictoryState()
    {
    }

    public virtual void UpdateState()
    {
    }

    internal void Look()
    {
        RaycastHit hit;

        //Chase logis is differnt
        if ((enemy.currentState.GetType() == typeof(BobChaseState)) ||(enemy.currentState.GetType() == typeof(BobMeleeAttackState)))
        {
            Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.Scanner.transform.position;
            Debug.DrawRay(enemy.Scanner.transform.position, enemyToTarget, Color.green);
            if (Physics.Raycast(enemy.Scanner.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
            {
                enemy.chaseTarget = hit.transform;
            }
            else
            {
                enemy.enteredstate = true;
                ToAlertState();
            }
        }
        else
        {
            int[] SweepAngle = { -45, -30, -15, 0, 15, 30, 45 };
            bool foundTarget = false;

            foreach (int angle in SweepAngle)
            {
                Debug.DrawRay(enemy.Scanner.transform.position, Quaternion.AngleAxis(angle, Vector3.up) * enemy.Scanner.transform.forward, Color.green);
                if (Physics.Raycast(enemy.Scanner.transform.position, Quaternion.AngleAxis(angle, Vector3.up) * enemy.Scanner.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
                {
                    enemy.chaseTarget = hit.transform;
                    foundTarget = true;
                    break;
                }
            }
            if (foundTarget)
            {
                enemy.enteredstate = true;
                ToChaseState();
            }

            //if (Physics.Raycast(enemy.Scanner.transform.position, enemy.Scanner.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
            //{
            //    enemy.chaseTarget = hit.transform;
            //    {
            //        ToChaseState();
            //    }
            //}
        }
    }

    internal void Search()
    {
        //Debug.Log("B>Scanning for player:" + searchTimer +":"+ enemy.searchingDuration);
        //enemy.meshRendererFlag.material.color = Color.yellow;
        enemy.navMeshAgent.Stop();

        //Spin till you find the player
        enemy.transform.Rotate(0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
        searchTimer += Time.deltaTime;

        if (searchTimer >= enemy.searchingDuration)
        {
            enemy.enteredstate = true;
            ToPatrolState();
        }
    }
}