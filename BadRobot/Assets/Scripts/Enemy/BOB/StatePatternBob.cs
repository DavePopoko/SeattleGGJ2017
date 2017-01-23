using UnityEngine;
using System.Collections;

public class StatePatternBob : MonoBehaviour
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
    [HideInInspector] public BobChaseState chaseState;
    [HideInInspector] public BobAlertState alertState;
    [HideInInspector] public BobPatrolState patrolState;
    [HideInInspector] public BobMeleeAttackState meleeState;
    [HideInInspector] public BobRangeAttackState rangedState;
    [HideInInspector] public BobVictoryState victoryState;
	[HideInInspector] public BobDefeatState defeatState;

    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;


    private void Awake()
    {
        chaseState = new BobChaseState(this);
        alertState = new BobAlertState(this);
        patrolState = new BobPatrolState(this);
        meleeState = new BobMeleeAttackState(this);
        rangedState = new BobRangeAttackState(this);
        victoryState = new BobVictoryState(this);
		defeatState = new BobDefeatState(this);

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