using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleswitch : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject togglebtn;

    //public Color Sel = Color.white.RGBA(255, 255, 255, 255);
    //public Color DeS;
    public bool act = true;
    public void swtoggle()
    {
        Image[] childrenImages = GetComponentsInChildren<Image>();
        foreach (Image childImage in childrenImages)
             if(childImage.color == Color.white)
                childImage.color=Color.black;
            else
            {
                childImage.color = Color.white;
            }
              //childImage.enabled = !childImage.enabled;            
      //  Gameobimg=togglebtn.GetComponentsInChildren<Image>)();
        // togglebtn.SetActive(!togglebtn.activeSelf);
    }

    public void tggle()
    {
        Toggle[] childrenImages = GetComponents<Toggle>();
        print("8888888");
        foreach (Toggle childImage in childrenImages)
        {
            bool newstat = !childImage.isOn;
            print("newstat= " + newstat);
            //   print(childImage.isOn);
            childImage.isOn = newstat;
            //  Gameobimg=togglebtn.GetComponentsInChildren<Image>)();
            // togglebtn.SetActive(!togglebtn.activeSelf);
        }
    }


    void Start()
    {
        Image[] childrenImages = GetComponentsInChildren<Image>();
        foreach (Image childImage in childrenImages)
            if (act==false)
                childImage.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
