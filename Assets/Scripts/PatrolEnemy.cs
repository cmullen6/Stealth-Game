using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PatrolEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float baseSpeed = 2f;
    public float chaseSpeed = 5f;

    int patrolIndex;
    NavMeshAgent agent;
    EnemyDetection detection;
    Transform player;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponent<EnemyDetection>();
        player = GameObject.FindWithTag("Player").transform;

        detection.OnAlertLevelChanged += UpdateAlertness;
    }

    void Start()
    {
        agent.destination = patrolPoints[0].position;
        UpdateAlertness(0);
    }

    void Update()
    {
        if (detection.alertLevel == 2)
        {
            agent.destination = player.position;
            return;
        }

        if (agent.remainingDistance < 0.2f)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            agent.destination = patrolPoints[patrolIndex].position;
        }
    }

    void UpdateAlertness(int level)
    {
        agent.speed = level == 2 ? chaseSpeed : baseSpeed + level;
    }
}
