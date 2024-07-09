using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearToObject : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject object1, object2;

    public GameObject Activate;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(object1.transform.position, object2.transform.position);
        float maxDistance = 3.0f;
        bool isNear = distance <= maxDistance;

        if (isNear)
        {
            Activate.SetActive(true);
        }
        else
        {
            Activate.SetActive(false);


        }
    }
}