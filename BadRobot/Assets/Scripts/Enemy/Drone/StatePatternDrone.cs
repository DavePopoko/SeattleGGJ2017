using UnityEngine;

public class StatePatternDrone : MonoBehaviour
{
    [HideInInspector]
    public DroneAlertState alertState;

    public Animator animator;
    [HideInInspector]
    public DroneChaseState chaseState;

    [HideInInspector]
    public Transform chaseTarget;

    [HideInInspector]
    public IEnemyState currentState;

    [HideInInspector]
    public DroneMeleeAttackState meleeState;

    public MeshRenderer meshRendererFlag;
    public float movementspeed = 1f;
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    public Vector3 offset = new Vector3(0, .5f, 0);
    [HideInInspector]
    public DronePatrolState patrolState;

    [HideInInspector]
    public DroneRangeAttackState rangedState;

    public Transform Scanner;
    public float searchingDuration = 4f;
    public float searchingTurnSpeed = 120f;
    public float sightRange = 20f;
    [HideInInspector]
    public DroneVictoryState victoryState;

    public Transform[] wayPoints;
    private void Awake()
    {
        chaseState = new DroneChaseState(this);
        alertState = new DroneAlertState(this);
        patrolState = new DronePatrolState(this);
        meleeState = new DroneMeleeAttackState(this);
        rangedState = new DroneRangeAttackState(this);
        victoryState = new DroneVictoryState(this);

        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    // Use this for initialization
    private void Start()
    {
        currentState = patrolState;
    }

    // Update is called once per frame
    private void Update()
    {
        currentState.UpdateState();
    }
}