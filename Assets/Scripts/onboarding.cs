using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Reflection;
using System.Linq;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;

using System;
public class onboarding : MonoBehaviour

{
    AudioSource audioData;

    public UnityEvent onHandHoverEnd;

    //Get Initial Color
    //Color startColor;

    //The new color to be applied
    public Color newColor;
    public Color startColor;
    public float swtichTime = 3.0f;
    public float swtichTime1 = 2.0f;

    public float swtichTime2 = 20.0f;
    public GameObject aktiflestir;
    public GameObject aktif;
    public GameObject countScreen;
    void Start()
    {
        //Get the inital color
        //startColor = GetComponent<MeshRenderer>().material.color;
    }

    //Make sure a collider is present on that object
    private void OnHandHoverBegin()
    {
        StartCoroutine(ColorSwitch());
    }
  

    IEnumerator ColorSwitch()
    {
        aktif.SetActive(false);

        countScreen.SetActive(true);
        //Change the color instantly to new color
        GetComponent<MeshRenderer>().material.color = newColor;

        //Wait for 3 seconds
        yield return new WaitForSeconds(swtichTime);
        aktiflestir.SetActive(false);
        countScreen.SetActive(false);

        aktif.SetActive(true);

        //Switch to the previous color
        GetComponent<MeshRenderer>().material.color = startColor;

    }
}