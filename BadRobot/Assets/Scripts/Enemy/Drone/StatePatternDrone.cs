using UnityEngine;
using System.Collections;

public class StatePatternDrone : MonoBehaviour
{
    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public float sightRange = 20f;
    public float movementspeed = 1f;

    internal bool enteredstate = true;

    public Transform[] wayPoints;
    public Transform Scanner;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public MeshRenderer meshRendererFlag;
    public Animator animator;

    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public IEnemyState currentState;
    [HideInInspector] public DroneChaseState chaseState;
    [HideInInspector] public DroneAlertState alertState;
    [HideInInspector] public DronePatrolState patrolState;
    [HideInInspector] public DroneMeleeAttackState meleeState;
    [HideInInspector] public DroneRangeAttackState rangedState;
    [HideInInspector] public DroneVictoryState victoryState;
	[HideInInspector] public DroneDefeatState defeatState;

    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;


    private void Awake()
    {
        chaseState = new DroneChaseState(this);
        alertState = new DroneAlertState(this);
        patrolState = new DronePatrolState(this);
        meleeState = new DroneMeleeAttackState(this);
        rangedState = new DroneRangeAttackState(this);
        victoryState = new DroneVictoryState(this);
		defeatState = new DroneDefeatState(this);

        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Use this for initialization
    void Start()
    {
        currentState = patrolState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
}