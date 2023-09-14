using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filtrekontrol : MonoBehaviour
{
    public GameObject popup;
    public GameObject popupkapat;
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
        if (other.name == "filtre") 
        {
            if (popup != null)
            {
                popup.SetActive(true);
            }
            if (popupkapat != null)
                popupkapat.SetActive(false);
        }
    }
}
