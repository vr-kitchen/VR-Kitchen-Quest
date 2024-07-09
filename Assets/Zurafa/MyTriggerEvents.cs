using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyTriggerEvents : MonoBehaviour
{
    public GameObject objwaitingfor;
    public UnityEvent onTriggered;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (objwaitingfor != null)
        {
            if (other.name == objwaitingfor.name)
            {
                onTriggered.Invoke();
            }
        }
    }
}
