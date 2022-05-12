using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroling : MonoBehaviour
{
    [SerializeField] private Transform movePosition1;
    [SerializeField] private Transform movePosition2;
    [SerializeField] private Transform movePosition3;
    [SerializeField] private Transform movePosition4;
    [SerializeField] private Transform goToPlayer;


    bool canSee;
    private Transform enemyPosition;
    private int count = 0;
    private int nextPos;

    private NavMeshAgent navMeshAgent;
    
    private void Start()
    {
        nextPos = count + 1;
        navMeshAgent = GetComponent<NavMeshAgent>();
        canSee = false;


    }

    // Update is called once per frame
    void Update()
    {
        enemyPosition = gameObject.transform;
            canSee = GetComponent<FieldOfView>().canSeePlayer;
        

        if (!canSee)
        { 
        switch (count)
        { 
            case 0:
                {
                    navMeshAgent.destination = movePosition1.position;
                    break;
                }
            case 1:
                {
                    navMeshAgent.destination = movePosition2.position;
                    break;
                }
            case 2:
                {
                    navMeshAgent.destination = movePosition3.position;
                    break;
                }
            case 3:
                {
                    navMeshAgent.destination = movePosition4.position;
                    break;
                }

        }
        if (enemyPosition.position.x == navMeshAgent.destination.x && enemyPosition.position.z == navMeshAgent.destination.z && count != nextPos)
        {
            count++;
            if (count == 4)
                count = 0;
            nextPos = count +1;

        }
        }
        else 
        {
            
            navMeshAgent.destination = goToPlayer.position;
        }




    }
}
