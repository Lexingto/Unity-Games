using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StalkerAI : MonoBehaviour
{
    public GameObject stalkerdestination;
    public GameObject stalkerEnemy;

    private NavMeshAgent stalkerAgent;

    public Transform Player;

    void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        stalkerAgent.SetDestination(stalkerdestination.transform.position);
        transform.LookAt(Player);
    }
}
