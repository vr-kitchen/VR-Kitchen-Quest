using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class positionY : MonoBehaviour
   
{
    public GameObject obj;
    private void HandHoverUpdate(Hand hand)
    {
        Vector3 piv = obj.transform.position;
        piv.z = 0;
        piv.x = 0;
            
    }
        // Start is called before the first frame update
        void Start()
    {
        Vector3 piv = obj.transform.position;
        piv.z = 0;
        piv.x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 piv = obj.transform.position;
        piv.z = 0;
        piv.x = 0;
    }
}
