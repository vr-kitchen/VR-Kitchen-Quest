using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistanceCheck : MonoBehaviour
{
    public float mindistance;
    public GameObject camobj;
    public GameObject Object2hide;
    public GameObject[] Onboardingbtns;
    public GameObject[] Onboardinglights;
    public int len;



    // Start is called before the first frame update
    void Start()
    {
        len = Onboardingbtns.Length;

    }

    // Update is called once per frame
    void Update()
    {
        float distance =  Vector3.Distance(camobj.transform.position, Object2hide.transform.position);
        if (distance < mindistance)
        {
            Object2hide.gameObject.SetActive(false);

            
            for(int i=0; i<Onboardingbtns.Length;i++)
            {
                Onboardingbtns[i].SetActive(true);
            }
            for (int i = 0; i < Onboardinglights.Length; i++)
            {
                Onboardinglights[i].SetActive(true);
            }
        }
        else
        {
            Object2hide.gameObject.SetActive(true);
        }
    }
}
