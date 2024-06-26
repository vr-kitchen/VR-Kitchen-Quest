using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleGameOBJ : MonoBehaviour
{
    public GameObject[] objs;
    public bool stat = false;

    public void toggleStat()
    {
        stat = !stat;
        //GameObject[] childrenImages = GetComponentsInChildren<Image>();
        foreach (GameObject obj in objs)
                obj.SetActive(stat);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
