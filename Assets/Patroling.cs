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
    [SerializeField] private Transform movePosition5;
    [SerializeField] private Transform movePosition6;
    [SerializeField] private Transform movePosition7;
    [SerializeField] private Transform goToPlayer;
    public AudioClip alarm;

    bool canSee;
    bool canSee2;
    bool canSee3;
    private Transform enemyPosition;
    private int count = 0;
    private int nextPos;
    private GameObject ostatniaPozycja;
    private bool once = false;
    public CameraFieldOfView kameraWidzi;
    private bool kameraWykryla = false;
    


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
            canSee2 = GetComponent<FieldOfView>().canSeePlayer2;
            canSee3 = GetComponent<FieldOfView>().canSeePlayer3;
            



        if (!kameraWykryla) { 
        if (!canSee && !canSee2 && !canSee3)
        {
            navMeshAgent.speed = 3.5f;
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
            case 4:
                {
                            navMeshAgent.destination = movePosition5.position;
                            break;
                }
            case 5:
                {
                            navMeshAgent.destination = movePosition6.position;
                            break;
                }
            case 6:
                {
                            navMeshAgent.destination = movePosition7.position;
                            break;
                }
        }
        if (enemyPosition.position.x == navMeshAgent.destination.x && enemyPosition.position.z == navMeshAgent.destination.z && count != nextPos)
        {
            count++;
                if (count == 7)
                count = 0;
            nextPos = count +1;

        }
        }
        else
        {
          
            
            navMeshAgent.destination = goToPlayer.position;
            navMeshAgent.speed = 0.5f; 
        }
        }
        else
            navMeshAgent.destination = ostatniaPozycja.transform.position;

        if (kameraWidzi.detected >= 100 && kameraWidzi.canSeePlayer)
        {
            if (!ostatniaPozycja) { 
            navMeshAgent.destination = goToPlayer.position;
                
                once = true;
        }
        }
        else if (kameraWidzi.detected < 100 && !canSee && once)
        {
            ostatniaPozycja = new GameObject("lastSeen");
           
            ostatniaPozycja.transform.position = goToPlayer.position;
            
            kameraWykryla = true;
            once = false;
        }
        

    }
}
