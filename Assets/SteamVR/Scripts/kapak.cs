using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapak : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kapak1;

    //public float moveSpeed = -3f;
    public float rotSpeed = 1f;

    public float maxAngle = -45;
    public float minAngle = 0;




    void Start()
    {
        if (maxAngle < 0)
        {
            maxAngle += 360;
        }
        if (minAngle < 0)
        {
            minAngle += 360;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (kapak1.transform.eulerAngles.y > maxAngle && kapak1.transform.eulerAngles.y > 0)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);

        }




    }
  
 
    
}
