using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSelection : MonoBehaviour
{

    public Material[] outsidematerials;
    //public int activematerial=0;
    public GameObject[] outsidemeshes;
    public MonoBehaviour FSwitch; //= GameObject.Find("Fridge-options").GetComponent<FridgeSwitch>();

    // Start is called before the first frame update
    void Start()
    {
      FSwitch = GameObject.Find("Fridge-options").GetComponent<FridgeSwitch>();
      //GameObject.MaterialSelection
      Debug.Log(FSwitch);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMat(Material selectedmat)
    {
      for(int i=0;i<outsidemeshes.Length;i++)
        outsidemeshes[i].GetComponent<MeshRenderer>().material = selectedmat;
    }

    public Material[] ListMat(){
      return outsidematerials;
    }

}
