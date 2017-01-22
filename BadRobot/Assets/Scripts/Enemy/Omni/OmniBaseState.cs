using UnityEngine;

public class OmniBaseState : IEnemyState

{
    internal StatePatternOmni enemy;
    internal float searchTimer;

    public OmniBaseState()
    {
    }

    public OmniBaseState(StatePatternOmni statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
    }

    public virtual void ToAlertState()
    {
    }

    public virtual void ToChaseState()
    {
    }

    public virtual void ToMeleeAttackState()
    {
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
        if (enemy.currentState.GetType() == typeof(OmniChaseState))
        {
            Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.Scanner.transform.position;
            if (Physics.Raycast(enemy.Scanner.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
            {
                enemy.chaseTarget = hit.transform;
            }
            else
            {
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
        Debug.Log("Omni>Scanning for player:" + searchTimer +":"+ enemy.searchingDuration);
        enemy.meshRendererFlag.material.color = Color.yellow;
        enemy.navMeshAgent.Stop();

        //Spin till you find the player
        enemy.transform.Rotate(0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
        searchTimer += Time.deltaTime;

        if (searchTimer >= enemy.searchingDuration)
        {
            ToPatrolState();
        }
    }
}