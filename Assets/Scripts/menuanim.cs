using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuanim : MonoBehaviour
{

  public GameObject objecttoanimate;

  // The skewer types are big and small
  public string ButtonType = "";

  // This skewer's states can be up and down,
  public string SizeState = "";
  public string MovementState = "";

  // This is how fast the skewer should move up, down, wait
  //public float upSpeed = 0.15f;
//  public float downSpeed = 0.15f;
   Vector3 scaleChange =  new Vector3(0.3f, 0.00f, 0.00f);
   Vector3 positionChange = new Vector3(0.5f, 0.0f, 0.0f);
   public float framesforshift;

  // This is how far the skewer should move before it changes states
//  public float distanceToMove = 3.0f;
  // This is where our object starts, so we can compare how far it has moved
//  public float startingXposition;
  public RectTransform startingsize;
  public RectTransform sizetoscale;
  // This is the delay before the skewer starts to move
  public float startDelay = 1;
  public float counter = 0;
  // This is the delay between the skewer moving up and down
  public float waitDelay = 1;
  // This bool becomes true when the startDelay time has passed and the skewer can start to move
  //public bool readyToMove = false;

  // This float number will count how long this animation takes to complete
  public float animationTimer = 0;
  public int numberofAnimationStateChanges = 1;
  public bool timingAnimation = false;

    public void ButtonResize()
    {

        if(ButtonType == "Small")
          ChangeStatetoUp();
        else
          ChangeStatetoDown();
    }

    // Start is called before the first frame update
    void Start()
    {

  //    startingXposition = transform.localPosition.x;
//      startingsize = GetComponent<RectTransform>();
    //  Debug.Log("***" + startingsize.localScale.x + " -- " + startingsize.localScale.y);
    scaleChange.x = (sizetoscale.transform.localScale.x-startingsize.transform.localScale.x)/framesforshift;
    positionChange.x = (sizetoscale.transform.localPosition.x-startingsize.transform.localPosition.x)/framesforshift;

      ButtonType = "Small";
        this.transform.localScale=startingsize.transform.localScale;
        this.transform.localPosition=startingsize.transform.localPosition;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
    //  Debug.Log("*** button is"+ButtonType+":  " + SizeState +"-"+ MovementState + " -- " + transform.localScale.x + " -- " + transform.localPosition.x);

        // Count how much time has passed since we started each frame.
        counter += Time.deltaTime;
        if (counter >= startDelay)
        {
            // This skewer is ready to starting moving
          //  readyToMove = true;
            timingAnimation = true;
        }

        // Check if we are ready to start moving
/*
            if (numberofAnimationStateChanges < 4)
            {
                // Let's start counting
                animationTimer += Time.deltaTime;
            }
*/
            // Move us down if our state is Down
            if (MovementState == "Down")
            {
                //Vector3  = new Vector3(transform.localPosition.x, transform.localPosition.y - downSpeed, transform.localPosition.z);
                this.transform.localPosition -= positionChange;
                Debug.Log("<--");
            }
            else if (MovementState == "Up")
            {
              //  Vector3 nextPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + upSpeed, transform.localPosition.z);
                this.transform.localPosition += positionChange;
                Debug.Log("-->");

            }

            // Size us down if our state is Down
            if (SizeState == "Down")
            {
                //Vector3  = new Vector3(transform.localPosition.x, transform.localPosition.y - downSpeed, transform.localPosition.z);
                this.transform.localScale -= scaleChange;
            }
            else if (SizeState == "Up")
            {
              //  Vector3 nextPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + upSpeed, transform.localPosition.z);
                this.transform.localScale += scaleChange;
            }


            // What is our current position, if we have gone far enough to change our movement state
            positionCheck();
            scaleCheck();

    }

    private void positionCheck()
    {

      if (MovementState == "Up")
      {
        if(transform.localPosition.x<sizetoscale.transform.localPosition.x)
          {  Debug.Log("this object is on left!!!");
            MovementState = "Up";
          }
          else
            MovementState = "Wait";
      }
      if(MovementState == "Down")
      {
        if(transform.localPosition.x>startingsize.transform.localPosition.x)
            MovementState = "Down";
          else
            MovementState = "Wait";
      }
        //print("pos:" + transform.localPosition.x + " - " + startingsize.transform.localPosition.x + " - " + MovementState);

    }

    private void scaleCheck()
    {

      if(SizeState == "Up")
      {
        if(transform.localScale.x<sizetoscale.transform.localScale.x)
{
            SizeState = "Up";
}
          else
            {
                //  Debug.Log("this object is Big Enough!!!");
                SizeState = "Wait";
                ButtonType = "Big";
                GameObject.Find("Fridge-options").GetComponent<FridgeSwitch>().ActivateMainMenu();
            }
      }
      else if(SizeState == "Down")
      {
            if (transform.localScale.x > startingsize.transform.localScale.x)
                SizeState = "Down";
            else
            {
                SizeState = "Wait";
                ButtonType = "Small";
                GameObject.Find("Fridge-options").GetComponent<FridgeSwitch>().DeactivateMainMenu();
                GameObject.Find("Fridge-options").GetComponent<FridgeSwitch>().DestroyMatMenu();
                GameObject.Find("Fridge-options").GetComponent<FridgeSwitch>().DestroyModelMenu();


                // GameObject.Find("Fridge-options").GetComponent<FridgeSwitch>().DeactivateAllMenu();

                //  Debug.Log("this object is Small Enough!!!");
            }
        }
        //print("size:" + transform.localScale.x + " - " + startingsize.transform.localScale.x + " - " + SizeState);

    }


    public void ChangeStatetoUp()
    {
        MovementState = "Up";
        SizeState = "Up";
      //  numberofAnimationStateChanges++;
    }
    public void ChangeStatetoDown()
    {
        MovementState = "Down";
        SizeState = "Down";

    //    numberofAnimationStateChanges++;
    }


}
