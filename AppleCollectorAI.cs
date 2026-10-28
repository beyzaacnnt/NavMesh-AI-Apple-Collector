using UnityEngine;
using UnityEngine.AI;

public class AppleCollectorAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] appleWaypoints;
    private int currentTargetIndex = 0;
    public int collectedApples = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextApple();
    }

    void GoToNextApple()
    {
        if (appleWaypoints.Length == 0) return;
        agent.destination = appleWaypoints[currentTargetIndex].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            collectedApples++;
            Destroy(other.gameObject); // Elmayı sahneden sil
            
            // Bir sonraki elmanın hedefine git
            currentTargetIndex = (currentTargetIndex + 1) % appleWaypoints.Length;
            GoToNextApple();
        }
    }
}
