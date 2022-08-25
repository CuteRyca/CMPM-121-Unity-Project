using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    public float aggroRadius;
    Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
        
}

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;
        if (distanceToTarget <= aggroRadius)
        {
            agent.SetDestination(player.transform.position);
            
        }
        else {
            agent.SetDestination(startPosition);
        }
        
    }

   
}
