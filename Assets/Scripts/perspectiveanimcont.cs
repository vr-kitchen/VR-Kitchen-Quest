using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perspectiveanimcont : MonoBehaviour
{
    Animator anim;
    public bool animcontrstate;
    public GameObject perspectivebtn;
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

    public void buttonon()
    {
        anim.enabled = !perspectivebtn.activeSelf;
        perspectivebtn.SetActive(!perspectivebtn.activeSelf);
    }
}
