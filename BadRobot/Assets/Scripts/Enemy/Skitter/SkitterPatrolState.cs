using UnityEngine;

public class SkitterPatrolState : SkitterBaseState, IEnemyState

{
    //private readonly StatePatternSkitter enemy;
    private int nextWayPoint;

    public SkitterPatrolState(StatePatternSkitter statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter ALERT");
            ToAlertState();
        }
    }

    public override void ToAlertState()
    {
        Debug.Log("Enter ALERT");
        enemy.currentState = enemy.alertState;
    }

    public override void ToChaseState()
    {
        Debug.Log("Enter CHASE");
        enemy.currentState = enemy.chaseState;
    }

    //public void ToMeleeAttackState()
    //{
    //}

    //public void ToPatrolState()
    //{
    //    Debug.Log("Can't transition to same state");
    //}

    //public void ToRangeAttackState()
    //{
    //}

    //public void ToScanState()
    //{
    //}

    //public void ToVictoryState()
    //{
    //}

    public void UpdateState()
    {
        // Testing pew pew
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Fire!");

            //GameObject testPrefab = (GameObject)AssetDatabase.LoadAssetAtPath("Projectile", typeof(GameObject));

            var cubey = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubey.AddComponent< Rigidbody > ();
            
            GameObject bullet = GameObject.Instantiate(cubey, enemy.transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(enemy.transform.forward * 50);
        }

        Look();
        Patrol();
    }

    //private void Look()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(enemy.Scanner.transform.position, enemy.Scanner.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
    //    {
    //        enemy.chaseTarget = hit.transform;
    //        ToChaseState();
    //    }
    //}

    private void Patrol()
    {
        enemy.meshRendererFlag.material.color = Color.green;
        enemy.navMeshAgent.destination = enemy.wayPoints[nextWayPoint].position;
        enemy.navMeshAgent.Resume();

        if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
        }
    }
}