using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sıfırla : MonoBehaviour
{
    struct PositionAndRotation
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    public List<GameObject> objs;

    Dictionary<Transform, PositionAndRotation> initialPositions = new Dictionary<Transform, PositionAndRotation>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject stack in GameObject.FindGameObjectsWithTag("sıfırla"))
        {
            objs.Add(stack);

            //set all the books to be stationary
            var rb = stack.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            //store the initial transform of the individual books
            PositionAndRotation pandr;
            pandr.position = stack.transform.position;
            pandr.rotation = stack.transform.rotation;
            initialPositions[stack.transform] = pandr;
        }
        print("OBJS created------");
        print(objs.Count);

    }

    public void ResetBooks()
    {
        foreach (var pair in initialPositions)
        {
           // console.log(pair.gameObject.name);

            Transform t = pair.Key;
            t.position = pair.Value.position;
            t.rotation = pair.Value.rotation;
            var rb = t.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    public void Disappear()
    {
        /* foreach (GameObject stack1 in GameObject.FindGameObjectsWithTag("sıfırla"))
         {
             print(stack1.gameObject.name);
             stack1.SetActive(false);
         }*/
        GameObject[] obja = objs.ToArray();
        foreach (GameObject klk in objs)
            klk.SetActive(false);
    }
    public void Appear()
    {
        foreach (GameObject stack2 in GameObject.FindGameObjectsWithTag("sıfırla"))
        {
            print(stack2.gameObject.name+"active");
            stack2.SetActive(true);
        }
        GameObject[] obja = objs.ToArray();
        foreach (GameObject klk in objs)
            klk.SetActive(true);
    }
}