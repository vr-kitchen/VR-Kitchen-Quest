using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationHandler : MonoBehaviour
{
    public List<GameObject> notifiers;
    public int ActiveNotifier = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(notifiers.Count>0)
        {
            for (int x = 0; x < notifiers.Count; x++)
                notifiers[x].SetActive(false);
            notifiers[ActiveNotifier].SetActive(true);
        }
    }

    // Update is called once per frame
    public void Next()
    {
        notifiers[ActiveNotifier++].SetActive(false);
        notifiers[ActiveNotifier].SetActive(true);


    }
}
