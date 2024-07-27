using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
//**//  using UnityEditor.Events;

public class FridgeSwitch : MonoBehaviour
{
    //**//  public VRInputModule inputscript;
    public GameObject[] Fridges; //array of fridges to visible/nonvisible
  //public GameObject[] ActiveFridge;
  public int ActiveFridge; //th array number of active fridge
  //public RectTransform thecanvas; //canvas reference
  public Button ModelBtnTmp; //button template/prefab : ModelBtnTmp
  public RectTransform modelbuttonpos; //ModelsBtnPlacement
  public Button[] buttons; //buttons for fridge switch
  public float buttonmargin; //270 is the fit one.
  public GameObject[] mainmenubuttons; //UI buttons for fridge extra functions
  public string mainmenustate = "Passive"; //keeps if main buttons are visible/nonvisible
  public MaterialSelection FridgeMatsFn; //ref to materialselection.cs file
  public GameObject MatBtnTmp; //button template/prefab : MaterialBtnTmp
  public RectTransform matbuttonpos; //material selection placeholder: ColorsBtnPlacement
  public bool AirFlowStatus;
  public bool TrayAdjStatus;



    public UnityEvent<bool> buttonInteractableCaller;



    // Start is called before the first frame update
    void Start()
    {
        FridgeMatsFn = Fridges[ActiveFridge].GetComponent<MaterialSelection> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateMainMenu()
    {
      for(int i=0;i<mainmenubuttons.Length;i++)
        mainmenubuttons[i].SetActive(true);

        mainmenustate = "Active";
    }

    public void DeactivateMainMenu()
    {
      for(int i=0;i<mainmenubuttons.Length;i++)
        mainmenubuttons[i].SetActive(false);

        mainmenustate = "Passive";
    }

    public void DeactivateAllMenu()
    {
        DeactivateMainMenu();
        //GameObject activesubbuttons = buttons[0].GameObject;
        DestroyModelMenu();
        DestroyMatMenu();
        menuanim redbutton = GameObject.Find("RED BUTTON").GetComponent<menuanim>();
        redbutton.ChangeStatetoDown();
    }

    public void DestroyModelMenu() {
        //destroy modelbtns
        GameObject[] modelbtn = GameObject.FindGameObjectsWithTag("modelbutton");
        for (int i = 0; i < modelbtn.Length; i++)
            Destroy(modelbtn[i]);
    }

    public void DestroyMatMenu() { 
        //destroy material btns
        GameObject[] matbuttons = GameObject.FindGameObjectsWithTag("materialbutton");
        for (int i = 0; i < matbuttons.Length; i++)
            Destroy(matbuttons[i]);
    }


    public void fademainmenu(string submenutitle)
    {
        //  mainmenubuttons[3].SetActive(false);
        int selectedmenu = 0;
        if (submenutitle == "changemodel")
        {
            selectedmenu = 3;
            DeactivateMainMenu();
            DestroyMatMenu();

            mainmenubuttons[selectedmenu].SetActive(true);
            //  mainmenubuttons[selectedmenu].opacity = 0.5;
        }
        else if (submenutitle == "changemat")
        {
            selectedmenu = 1;
            DeactivateMainMenu();
            DestroyModelMenu();
            mainmenubuttons[selectedmenu].SetActive(true);
        }
    }




    public void MaterialSubButton()
    {
      //Reset the BtnPlacement point
      matbuttonpos.transform.localPosition=new Vector3(matbuttonpos.transform.localPosition.x,-200, matbuttonpos.transform.localPosition.z);

      //Create subbuttons array with necesarry length
      GameObject[] matbuttons = new GameObject[FridgeMatsFn.outsidematerials.Length];

      //calculate the shift for button palcement
      float buttonshift=FridgeMatsFn.outsidematerials.Length*buttonmargin/16;

      //reposition BtnPlacement point for centering
      matbuttonpos.transform.localPosition+=(Vector3.up*buttonshift/2);

      //Creating each subbutton with active positioning
      for(int i=0;i<matbuttons.Length;i++)
        {
            matbuttons[i]=Instantiate(MatBtnTmp,matbuttonpos,true);
            matbuttons[i].transform.localPosition=new Vector3(0f,0f,0f);
            matbuttons[i].transform.localPosition+=(Vector3.down*buttonshift*i);
            matbuttons[i].tag = "materialbutton";
            Button btn =matbuttons[i].GetComponent<Button>();
            
            //assign material preview for the button from outsidematerials ArrayUtility
            //  outsidemeshes[i].GetComponent<MeshRenderer>().material = selectedmat;
            Material[] Btnboxmats = matbuttons[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().materials;
            Btnboxmats[0] = FridgeMatsFn.outsidematerials[i];
            //Debug.Log("0000000:"+ matbuttons[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].name);
            matbuttons[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().materials=Btnboxmats;
            //Debug.Log("0001111:"+ matbuttons[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().materials[0].name);



            // assign clickevent for each sub material button

            UnityAction<GameObject> action = new UnityAction<GameObject>(SwMaterial);
       //**//  UnityEventTools.AddObjectPersistentListener<GameObject>(btn.onClick, action, matbuttons[i]);


        }//end of for


        // VRInputModule eventsystem = GameObject.Find("PR_VRInputModule").GetComponent<VRInputModule>();
        // print("the very famous eventdata:");
        // print(eventsystem.GetData());
        // eventsystem.ResetData();
        fademainmenu("changemat");
    }//end of function


    public void SwMaterial (GameObject sender)
    {

        // print("/*******************this is a click");
        //print(sender.GetComponentInChildren<Renderer>().material.name);
        SwitchMaterial(sender.GetComponentInChildren<Renderer>().material);

    }


    //onclick event it calls this function with its material
    public void SwitchMaterial(Material choosenMat){
      //GameObject MatSelectioncs = Fridges[ActiveFridge].parent.parent;
      //Debug.Log("++|||||++"+FridgeMatsFn.outsidematerials[activematerial].name);
      Debug.Log("this goes to ChangeMat function from SwitchMaterial" + choosenMat.name);
      FridgeMatsFn.ChangeMat(choosenMat);
        DeactivateAllMenu();
    }








    public void SwitchMenu()
    {

    modelbuttonpos.transform.localPosition=new Vector3(-502, modelbuttonpos.transform.localPosition.y,modelbuttonpos.transform.localPosition.z);

      //  GameObject go = Instantiate(buttonPrefab);
      //  var button = GetComponent<UnityEngine.UI.Button>();
      //  button.onClick.AddListener(() => FooOnClick());

// I have read that it is not possible to add new elements to the array if didn't give the size.
// Thus we re-initaite the array with enough size.
    buttons=new Button[Fridges.Length];
    float buttonshiftx=Fridges.Length*buttonmargin/2;
    modelbuttonpos.transform.localPosition+=(Vector3.left*buttonshiftx);

      for(int i=0;i<Fridges.Length;i++)
        {
            buttons[i]=Instantiate(ModelBtnTmp,modelbuttonpos,true);

            buttons[i].transform.localPosition=new Vector3((buttonshiftx*i*Fridges.Length),0f,0f);
            buttons[i].tag = "modelbutton";
                                                                                              
            Text text = buttons[i].GetComponentInChildren<Text>();
            if (text)
            {
                text.text = Fridges[i].name;
                text.name = i.ToString();
            }

           // buttons[i].onClick.AddListener(delegate { Debug.Log("this is an listener!!!"+buttons[i].GetComponentInChildren<Text>().text);});

            //    public void SwitchFridge(int choosen)

            UnityAction<GameObject> action = new UnityAction<GameObject>(SwitchFridge);
        //**//  UnityEventTools.AddObjectPersistentListener<GameObject>(buttons[i].onClick, action, Fridges[i]);

        }//end of for
        fademainmenu("changemodel");
    }



    public void SwitchFridge(GameObject choosen)
    {
        print(Fridges[ActiveFridge].name);
        print(">>>>>>" + choosen.name);
        // print("88888" + Fin);
        // GameObject new = GameObject.Find<choosen.name>();

        if (Fridges[ActiveFridge].name != choosen.name)
        {
            Fridges[ActiveFridge].SetActive(false);
            //ActiveFridge = choosen.GetComponentInChildren<Text>().name;
            choosen.SetActive(true);

            for (int i = 0; i < Fridges.Length; i++)
                if (Fridges[i].name == choosen.name)
                    ActiveFridge = i;
        }

        FridgeMatsFn = Fridges[ActiveFridge].GetComponent<MaterialSelection>();
        DeactivateAllMenu();

    }


    public void switchairflow()
    {
        print("+++++activefridge:" + ActiveFridge + "--fridge:" + Fridges[ActiveFridge].name);

        GameObject sim = Fridges[ActiveFridge].transform.Find("Airflow").gameObject;


        if (sim != null)
        {
            print("4444444" + sim.activeSelf + AirFlowStatus);
            if (AirFlowStatus)
            {
                print("Airflow is Active");
                sim.SetActive(false);
                Fridges[ActiveFridge].transform.Find("firstdoor").gameObject.SetActive(true);
                AirFlowStatus = false;
            }
            else
            {
                print("Airflow is not active");
                sim.SetActive(true);
                Fridges[ActiveFridge].transform.Find("firstdoor").gameObject.SetActive(false);
                AirFlowStatus = true;
            }
        }
    }

    public void TrayAdjSwitch()
    {
        print("+++++activefridge:" + ActiveFridge + "--fridge:" + Fridges[ActiveFridge].name);

        GameObject[] pocket = GameObject.FindGameObjectsWithTag("Tray");
        bool stat = !TrayAdjStatus;
        if (pocket!=null)
        {
            // print(TrayAdjStatus + "TrayAdjStatus  ->" + stat);
            // print(pocket.Length + "pocket length");


            //**//   for (int i = 0; i < pocket.Length; i++)
            //**//   {
            //**//       if(pocket[i].GetComponent<Valve.VR.InteractionSystem.Interactable>())
            //**//            pocket[i].GetComponent<Valve.VR.InteractionSystem.Interactable>().enabled=stat;
            //**//       /*else if(pocket[i].GetComponent<MeshCollider>())
            //**//       {
            //**//           pocket[i].GetComponent<MeshCollider>().enabled = stat;
            //**//       }*/
            //**//   }
        }
        if (stat)
            Fridges[ActiveFridge].transform.Find("firstdoor").transform.Rotate(0.0f, -125.0f, 0.0f, Space.Self);

        else if (!stat)
        {
            print("door should be close now");
            Fridges[ActiveFridge].transform.Find("firstdoor").transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        }

        TrayAdjStatus = stat;
    }




}
