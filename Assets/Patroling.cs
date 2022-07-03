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
    public AudioClip alarm;
    public AudioClip searching;

    public bool canSee;
    public bool canSee2;
    public bool canSee3;
    public Transform enemyPosition;
    public int count = 0;
    public int nextPos;
    public GameObject ostatniaPozycja;
    public bool once = false;
    public CameraFieldOfView kameraWidzi;
    public bool kameraWykryla = false;
    public bool poczatkowyKatWidzenia = false;
    [SerializeField] private int licz=0;
    public bool lewo;
    public bool srodek;
    public bool prawo;
    public Light spotlight;

    public Vector3 start ;
    


    private NavMeshAgent navMeshAgent;
/*    IEnumerator Rotatee(Transform self, Quaternion from, Quaternion to, float duration)
    {

        for (float t = 0; t < 1f; t += Time.deltaTime / duration)
        {
            // Rotate to match our current progress between from and to.
            //self.Rotate(Quaternion.Slerp(from, to, t)) = Quaternion.Slerp(from, to, t);
            // Wait one frame before looping again.
            yield return null;
        }

        // Ensure we finish exactly at the destination orientation.
        self.rotation = to;
    }*/
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




        if (!kameraWykryla)
        {
            Destroy(ostatniaPozycja);
            if (!canSee && !canSee2 && !canSee3)
            {
                navMeshAgent.speed = 3.5f;
                poczatkowyKatWidzenia = false;
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
                    nextPos = count + 1;

                }
            }
            else
            {


                navMeshAgent.destination = goToPlayer.position;
                navMeshAgent.speed = 0.5f;
            }
        }
        else
        { navMeshAgent.destination = ostatniaPozycja.transform.position;
            if (enemyPosition.position.x == navMeshAgent.destination.x && enemyPosition.position.z == navMeshAgent.destination.z && count != nextPos)
            {
                AudioSource.PlayClipAtPoint(searching, transform.position);
                spotlight.color = new Color(1.0f, 0.4f, 0.0f, 0.3f);
                if (poczatkowyKatWidzenia == false)
                {
                    start = enemyPosition.rotation.eulerAngles;
                    poczatkowyKatWidzenia = true;
                }


                float[] odleglosc = new float[4]
                {   Mathf.Sqrt(Mathf.Pow(movePosition1.position.x - enemyPosition.position.x,2) + Mathf.Pow(movePosition1.position.z - enemyPosition.position.z,2)),
                    Mathf.Sqrt(Mathf.Pow(movePosition2.position.x - enemyPosition.position.x,2) + Mathf.Pow(movePosition2.position.z - enemyPosition.position.z,2)),
                    Mathf.Sqrt(Mathf.Pow(movePosition3.position.x - enemyPosition.position.x,2) + Mathf.Pow(movePosition3.position.z - enemyPosition.position.z,2)),
                    Mathf.Sqrt(Mathf.Pow(movePosition4.position.x - enemyPosition.position.x,2) + Mathf.Pow(movePosition4.position.z - enemyPosition.position.z,2))
                };

                float minValue = Mathf.Min(odleglosc);

                for (int i = 0; i < odleglosc.Length; i++)
                {
                    if (minValue == odleglosc[i])
                        count = i;
                }

                if (poczatkowyKatWidzenia == true)
                {  

                    switch (licz)
                    {
                        case 0:
                            {
                                enemyPosition.transform.Rotate(0, -0.5f, 0);
                                lewo = true;
                                if (enemyPosition.rotation.eulerAngles.y <= start.y - 90) { 
                                    licz++;
                                }
                                break;
                            }
                        case 1:
                            {
                                enemyPosition.transform.Rotate(0, 1f, 0);
                                lewo = false;
                                prawo = true;
                                if (enemyPosition.rotation.eulerAngles.y >= start.y + 60)
                                {
                                    licz++;
                                }
                                break;
                            }
                        case 2:
                            {
                                enemyPosition.transform.Rotate(0, -0.5f, 0);
                                prawo = false;
                                srodek = true;
                                if (enemyPosition.rotation.eulerAngles.y <= start.y)
                                {
                                    licz = 0;



                                    srodek = false;
                                    start = new Vector3(0f, 0f, 0f);
                                    kameraWykryla = false;

                                }
                                break;
                            }

                    }


                /*if (licz == 0 && enemyPosition.rotation.eulerAngles.y <= start.y - 90 && lewo == true)
                    licz++;
                if (licz == 1 && enemyPosition.rotation.eulerAngles.y >= start.y + 60 && prawo == true)
                    licz++;
                if(licz == 2 && enemyPosition.rotation.eulerAngles.y <= start.y)
                {
                    licz = 0;
                        
                    
                    
                    srodek = false;
                    start = new Vector3(0f, 0f, 0f);
                    kameraWykryla = false;
                    
                    }*/


                    
                }


                
               
            }
        }

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
