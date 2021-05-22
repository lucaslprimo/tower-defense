using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform playerBase;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerBase = GameObject.FindGameObjectWithTag("PlayerBase").transform;
        agent.SetDestination(playerBase.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
