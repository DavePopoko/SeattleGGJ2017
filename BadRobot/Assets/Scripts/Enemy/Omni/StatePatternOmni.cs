using UnityEngine;
using System.Collections;

public class StatePatternOmni : MonoBehaviour
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
    [HideInInspector] public OmniChaseState chaseState;
    [HideInInspector] public OmniAlertState alertState;
    [HideInInspector] public OmniPatrolState patrolState;
    [HideInInspector] public OmniMeleeAttackState meleeState;
    [HideInInspector] public OmniRangeAttackState rangedState;
    [HideInInspector] public OmniVictoryState victoryState;

    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;


    private void Awake()
    {
        chaseState = new OmniChaseState(this);
        alertState = new OmniAlertState(this);
        patrolState = new OmniPatrolState(this);
        meleeState = new OmniMeleeAttackState(this);
        rangedState = new OmniRangeAttackState(this);
        victoryState = new OmniVictoryState(this);

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