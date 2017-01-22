using UnityEngine;
using System.Collections;

public class StatePatternSkitter : MonoBehaviour
{
    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public float sightRange = 20f;
    public float movementspeed = 1f;

    public Transform[] wayPoints;
    public Transform Scanner;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public MeshRenderer meshRendererFlag;
    public Animator animator;

    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public IEnemyState currentState;
    [HideInInspector] public SkitterChaseState chaseState;
    [HideInInspector] public SkitterAlertState alertState;
    [HideInInspector] public SkitterPatrolState patrolState;
    [HideInInspector] public SkitterMeleeAttackState meleeState;
    [HideInInspector] public SkitterRangeAttackState rangedState;
    [HideInInspector] public SkitterVictoryState victoryState;

    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;


    private void Awake()
    {
        chaseState = new SkitterChaseState(this);
        alertState = new SkitterAlertState(this);
        patrolState = new SkitterPatrolState(this);
        meleeState = new SkitterMeleeAttackState(this);
        rangedState = new SkitterRangeAttackState(this);
        victoryState = new SkitterVictoryState(this);

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