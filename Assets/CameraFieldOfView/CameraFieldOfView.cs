using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CameraFieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    public float detected;
    public GameObject ostatniaPozycja;
    private bool once = true;
    public Light spotlight;
    public AudioClip audioDetected1;
    public AudioClip audioDetected2;

    void Start()
    {

        StartCoroutine(FOVRoutine());


    }
    private IEnumerator FOVRoutine()
    {

        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            CameraFieldOfViewCheck();
        }

    }

    private void CameraFieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        //canSeePlayer
        if (rangeChecks.Length != 0)
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


        //detected
        if (!canSeePlayer && detected > 0)
            detected -= 3;

        if (canSeePlayer && detected <= 100)
            detected += 4;


        if(detected>0)
        {
            spotlight.color = new Color(1f, 1f-(detected/100), 0.0f, 0.4f);
        }

        //detected color of light
        if (detected > 0 && detected < 50)
        {
            AudioSource.PlayClipAtPoint(audioDetected1, transform.position);
        }
        else if (detected > 50 && detected < 100)
        {
            AudioSource.PlayClipAtPoint(audioDetected2, transform.position);
        }
        else if (detected >= 100)
            spotlight.color = Color.red;
        else
            spotlight.color = Color.cyan;


    }




}
