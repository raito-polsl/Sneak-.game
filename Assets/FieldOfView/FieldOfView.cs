using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    public float radius2;
    public float radius3;
    [Range(0,360)]
    public float angle;

    public GameObject  playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    public bool canSeePlayer2;
    public bool canSeePlayer3;
    public int detected;
    void Start()
    {
       
        StartCoroutine(FOVRoutine());


    }
    private IEnumerator FOVRoutine()
    {

        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while(true)
        {
            yield return wait;
            FieldOfViewCheck();
        }

    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        Collider[] rangeChecks2 = Physics.OverlapSphere(transform.position, radius2, targetMask);
        Collider[] rangeChecks3 = Physics.OverlapSphere(transform.position, radius3, targetMask);


        //canSeePlayer
        if (rangeChecks.Length != 0 && rangeChecks2.Length == 0 && rangeChecks3.Length == 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < (angle / 2))
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                    canSeePlayer = false;
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
            canSeePlayer = false;


        //canSeePlayer2
        if (rangeChecks.Length != 0 && rangeChecks2.Length != 0 && rangeChecks3.Length == 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < (angle / 2))
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer2 = true;
                }
                else
                    canSeePlayer2 = false;
            }
            else
            {
                canSeePlayer2 = false;
            }
        }
        else if (canSeePlayer2)
            canSeePlayer2 = false;

        //canSeePlayer3
        if (rangeChecks.Length != 0 && rangeChecks2.Length != 0 && rangeChecks3.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < (angle / 2))
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer3 = true;
                }
                else
                    canSeePlayer3 = false;
            }
            else
            {
                canSeePlayer3 = false;
            }
        }
        else if (canSeePlayer3)
            canSeePlayer3 = false;


        if (!canSeePlayer && !canSeePlayer2 && !canSeePlayer3)
            detected = 0;

        if (canSeePlayer)
            detected += 3;
        else if (canSeePlayer2)
            detected += 10;
        else if (canSeePlayer3)
            detected += 20;

        if(detected >= 100)
        {
            Debug.Log("Przegrales");
        }

    }




}
