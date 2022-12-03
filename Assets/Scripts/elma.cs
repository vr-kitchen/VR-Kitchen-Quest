using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elma : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Activate;
    public GameObject deactivate;

    private int count=0;

    private void Update()
    {
       
            StartCoroutine(ExampleCoroutine());

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ColliderTrigger" && count == 0)
        {
            Activate.SetActive(true);
            count++;
            

        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "ColliderTrigger")
        {
            Activate.SetActive(false);



        }
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.

        //yield on a new YieldInstruction that waits for 5 seconds.
        if (count != 0)
        {
            yield return new WaitForSeconds(5);
            Activate.SetActive(false);
            deactivate.SetActive(false);
        }

        //After we have waited 5 seconds print the time again.
    }
}
