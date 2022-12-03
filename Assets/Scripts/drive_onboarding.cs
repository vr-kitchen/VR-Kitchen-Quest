using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive_onboarding : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject object1, object2, object3;

    public GameObject Activate;
    public GameObject Activate1;

    private bool isNear1;
    public int counter;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(object1.transform.position, object2.transform.position);
        float distance1 = Vector3.Distance(object1.transform.position, object3.transform.position);
        float maxDistance = 0.02f;
        bool isNear = distance <= maxDistance;
        isNear1 = distance1 <= maxDistance;
        if (isNear)
        {
            Activate.SetActive(true);
            Activate1.SetActive(false);
            counter = 1;
        }
        else
        {
            Activate.SetActive(false);


        }
        if (counter % 2 == 1)
        {
            if (isNear1)
            {
                Activate.SetActive(false);
                Activate1.SetActive(true);
                counter = 0;
            }

            


        }
        if (!isNear1)
        {
            Activate1.SetActive(false);
        }

    }

    void close()
    {

        if (isNear1)
        {
            Activate.SetActive(false);
            Activate1.SetActive(true);
        }

    }
}
