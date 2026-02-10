using UnityEngine;
using UnityEngine.AI;

public class EnemySearch : MonoBehaviour
{
    public float searchDuration = 3f;

    NavMeshAgent agent;
    EnemyDetection detection;

    Vector3 lastKnownPosition;
    float searchTimer;
    bool searching;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponent<EnemyDetection>();
    }

    void Update()
    {
        if (detection.alertLevel == 2)
        {
            lastKnownPosition = GameObject.FindWithTag("Player").transform.position;
            searching = true;
            searchTimer = searchDuration;
        }

        if (searching && detection.alertLevel < 2)
        {
            agent.destination = lastKnownPosition;
            searchTimer -= Time.deltaTime;

            if (searchTimer <= 0)
                searching = false;
        }
    }
}
