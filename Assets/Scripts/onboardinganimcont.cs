using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onboardinganimcont : MonoBehaviour
{
    Animator anim;
    public bool animcontrstate;
    public GameObject[] subbuttons;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void patlat()
    {
        bool animstate = anim.GetBool("patlat");
            //anim.enabled = true;
       // print("this is the animstate now!!!    : " + !animstate);
            anim.SetBool("patlat", !animstate);
           // anim.enabled = false;
    }

    public void buttonswitch()
    {
        for (int i = 0; i < subbuttons.Length; i++)
        {
            //anim.enabled = !subbuttons[i].activeSelf;
            subbuttons[i].SetActive(!subbuttons[i].activeSelf);
        }
    }
}
