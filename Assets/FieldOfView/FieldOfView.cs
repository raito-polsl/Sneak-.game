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

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < (angle / 2))
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    if (rangeChecks2.Length != 0)
                        canSeePlayer2 = true;
                    else
                        canSeePlayer2 = false;

                if (rangeChecks3.Length != 0)
                   canSeePlayer3 = true;
                else
                   canSeePlayer3 = false;

                    canSeePlayer = true;
                }
                else
                    canSeePlayer = false;
                canSeePlayer2 = false;
                canSeePlayer3 = false;
            }
            else
            {
                canSeePlayer = false;
                canSeePlayer2 = false;
                canSeePlayer3 = false;
            }
        }
        else if (canSeePlayer)
            canSeePlayer = false;
            canSeePlayer2 = false;
            canSeePlayer3 = false;
    }

}
