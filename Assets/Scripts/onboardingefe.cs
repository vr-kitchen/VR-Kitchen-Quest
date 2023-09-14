using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Reflection;
using System.Linq;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;

using System;
public class onboardingefe : MonoBehaviour

{
    AudioSource audioData;

    //public UnityEvent onHandHoverEnd;

    //Get Initial Color
    //Color startColor;

    //The new color to be applied
    public Color newColor;
    public Color startColor;
    public float swtichTime = 4.0f;
    public float swtichTime1 = 2.0f;

    public float swtichTime2 = 20.0f;
    public GameObject aktiflestir;
    public GameObject aktif;
    public GameObject countScreen;

    public bool pressed = false;
    public bool anim = false;

    void Start()
    {
        //Get the inital color
        //startColor = GetComponent<MeshRenderer>().material.color;
    }

    //Make sure a collider is present on that object
    private void OnHandHoverBegin()
    {
        pressed = true;
        StartCoroutine(ColorSwitch());
    }

    public void onHandHoverEnd()
    {
        pressed = false;
        countScreen.SetActive(false);
        GameObject.Find("wash-OnbBTN-2").GetComponent<onboardingefe>().anim = false;
        GameObject.Find("wash-OnbBTN-1").GetComponent<onboardingefe>().anim = false;

        print("-------> onhandend");
        print(GameObject.Find("wash-OnbBTN-1").GetComponent<onboardingefe>().pressed);
        print(GameObject.Find("wash-OnbBTN-2").GetComponent<onboardingefe>().pressed);

        //StartCoroutine(ColorSwitch());
    }


    IEnumerator ColorSwitch()
    {
        aktif.SetActive(false);
        print("-------> colorswitch");

       // print(GameObject.Find("wash-OnbBTN-1").GetComponent<onboardingefe>().pressed);
       // print(GameObject.Find("wash-OnbBTN-2").GetComponent<onboardingefe>().pressed);
        bool bothpressed = (GameObject.Find("wash-OnbBTN-2").GetComponent<onboardingefe>().pressed && GameObject.Find("wash-OnbBTN-1").GetComponent<onboardingefe>().pressed);
        GameObject.Find("wash-OnbBTN-2").GetComponent<onboardingefe>().anim = true;
        GameObject.Find("wash-OnbBTN-1").GetComponent<onboardingefe>().anim = true;
        print(bothpressed);

        if (bothpressed)
       {
           print("--> double press is active");
            countScreen.SetActive(true);

            //Change the color instantly to new color
            GetComponent<MeshRenderer>().material.color = newColor;

            //Wait for 3 seconds
            yield return new WaitForSeconds(swtichTime);
            bothpressed = (GameObject.Find("wash-OnbBTN-2").GetComponent<onboardingefe>().pressed && GameObject.Find("wash-OnbBTN-1").GetComponent<onboardingefe>().pressed);
            bool bothanim = (GameObject.Find("wash-OnbBTN-2").GetComponent<onboardingefe>().anim && GameObject.Find("wash-OnbBTN-1").GetComponent<onboardingefe>().anim);
            if (bothpressed && bothanim)
            {
                aktiflestir.SetActive(false);
                countScreen.SetActive(false);
                aktif.SetActive(true);

            }


            //if (GameObject.Find("wash-OnbBTN-2").GetComponent<onboardingefe>().anim && GameObject.Find("wash-OnbBTN-1").GetComponent<onboardingefe>().anim);

            //Switch to the previous color
            GetComponent<MeshRenderer>().material.color = startColor;

        }


    }
}