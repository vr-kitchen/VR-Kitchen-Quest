using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreenWizard : MonoBehaviour
{

    public GameObject[] Teleportpoints;
    int step = 0;
    public GameObject trained;
    GameObject waitingcollide;
    public float mindistance;
    public GameObject ply; //player
    public GameObject expertPoint;






    // Start is called before the first frame update
    void Start()
    {
        if (Teleportpoints[step])
        {
            Teleportpoints[step].SetActive(true);
            waitingcollide = Teleportpoints[step];
        }

        trained = GameObject.Find("TrainingTracker");
        if (trained.GetComponent<WelcomeFirstComerTracker>().trained == true)
        {
            print("-----------------------------------he is king :)");
            for (var t = 0; t < Teleportpoints.Length; t++)
            { NextStep();
                print("-----------------------------------he is king :)");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(ply.transform.position, waitingcollide.transform.position);
        float distanceexpert = Vector3.Distance(ply.transform.position, expertPoint.transform.position);
      //   print(distanceexpert);
        if (distance < mindistance)
        {
            NextStep();
        }
        else if(distanceexpert < mindistance*2)
        {
            trained.GetComponent<WelcomeFirstComerTracker>().trained = true;

        }
    }
        void NextStep()
    {
        if (Teleportpoints.Length > step)
        {
            step++;
            if (Teleportpoints[step])
            {
                Teleportpoints[step].SetActive(true);
                waitingcollide = Teleportpoints[step];
            }
        }
        else
            trained.GetComponent<WelcomeFirstComerTracker>().trained = true;
    }



}
