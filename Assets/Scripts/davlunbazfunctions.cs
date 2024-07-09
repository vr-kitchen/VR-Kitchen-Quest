using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class davlunbazfunctions : MonoBehaviour
{
    public GameObject supLight;
    public GameObject sound;
    public GameObject davlumbaz;
    public int state = 0;


    public void lightswitch()
    {
        if (supLight.activeSelf == false)
        {
            supLight.SetActive(true);
            davlumbaz.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }
        else
        {
            supLight.SetActive(false);
            davlumbaz.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");

        }
    }
    public void motorswitch()
    {
        state++;
        if (state % 2 == 0)
            sound.SetActive(true);
        else
            sound.SetActive(false);
    }

}
