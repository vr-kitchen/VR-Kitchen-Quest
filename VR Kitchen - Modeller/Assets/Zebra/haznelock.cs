using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class haznelock : MonoBehaviour
{
    public bool locked = false;
    public GameObject sukabiLocked;
    public AudioSource clip;
    // Start is called before the first frame update
    void Start()
    {
        clip = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (other.name == "sukabi")
        {
            print("----- inside if");
            locked = true;
            other.gameObject.SetActive(false);
            if (sukabiLocked != null)
                sukabiLocked.SetActive(true);
            clip.Play();
            this.gameObject.SetActive(false);
        }
    
    }
}
