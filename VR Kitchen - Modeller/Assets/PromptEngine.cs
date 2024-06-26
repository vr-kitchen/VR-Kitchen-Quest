using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptEngine : MonoBehaviour
{
    public List<GameObject> PromptFabs;
    public List<UXPrompt> Prompts;

    public int Prompti = 0;
    public int MaxVisiblePrompt = 2;
    public int SpawnAnimDistance = 40;
    public float AnimationDelayTime = .1f;

    public float SpawnRemoveTime= 30f;





    public GameObject root;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PromptinSeries());

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewPrompt(int type, string text)
    {
        Prompts.Add(new UXPrompt(type, text));
    }

    public IEnumerator PromptinSeries()
    {
        for (Prompti=0; Prompti < Prompts.Count; Prompti++)
        {
            AskPrompt();
            yield return new WaitForSeconds(10f);

        }
    }


    public void AskPrompt()
    {
        if (root != null && Prompti < Prompts.Count)
        {
            //instantiate and assign parameters
            GameObject p = Instantiate(PromptFabs[Prompts[Prompti].GetType()]);
            GameObject pcont = p.transform.Find("Container").gameObject;
            pcont.GetComponentInChildren<SpawnPrompt>().PromptText = Prompts[Prompti].PromptText;
            pcont.GetComponentInChildren<Button>().onClick.AddListener(() => this.AskPrompt());

            //reset position, scale to root transform and assign to root
            p.transform.localScale = root.transform.localScale;

            SpawnPrompt(p);




        }
    }


    public void SpawnPrompt(GameObject p)
    {
        p.transform.parent = root.transform;
        p.transform.localPosition = Vector3.zero;
        p.transform.localRotation = Quaternion.identity;

        //call show animation
        StartCoroutine(SpawnAnim(p));
        print(root.transform.childCount);
        if (root.transform.childCount > MaxVisiblePrompt)
            Destroy(root.transform.GetChild(0).gameObject);
    }

    public IEnumerator SpawnAnim(GameObject p)
    {
        

        Transform promptcont = p.transform.Find("Container");
        float targety = promptcont.localPosition.y;//transform.localPosition.y;
        float targetx = promptcont.localPosition.x;
        promptcont.localPosition = new Vector3(targetx, SpawnAnimDistance*-1, 0);

        for (float yy=SpawnAnimDistance*-1; yy < targety; yy += 1)
        {
            promptcont.localPosition = new Vector3(targetx, yy, 0);
            //print(yy +"--"+ promptcont.localPosition.x);
            if (yy <= targety)
                StartCoroutine(RemovePrompt(p));
            yield return new WaitForSeconds(AnimationDelayTime);
        }
    }

    



    public IEnumerator RemovePrompt(GameObject p)
    {
        print("*****inside the removeprompt");
        yield return new WaitForSeconds(SpawnRemoveTime);
        //p.SetActive(false);
        Destroy(p);
    }

    // IEnumerator Fade()
    // {
    //     //Color c = renderer.material.color;
    //     for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
    //     {
    //         c.a = alpha;
    //       //  renderer.material.color = c;
    //         yield return new WaitForSeconds(.1f);
    //     }
    // }



    [System.Serializable]
    public class UXPrompt
    {
        public string PromptText;
        //public int Ptype;
        public Prompttype Type;
        public float SpawnDelayTime = 150f;
        public float DestroyDelayTime = 500f;
        public bool Spawned;

        // Unity requires a default constructor for serialization
        public UXPrompt() { }
        public UXPrompt(int type, string text)
        {
            //Ptype = type;
            Type = (Prompttype)type;
            PromptText = text;
            SpawnDelayTime = 150f;
            DestroyDelayTime = 500f;
            Spawned = false;
        }
        public UXPrompt(int type, string text, float spawntime, float destroytime)
        {
            //Ptype = type;
            Type = (Prompttype)type;
            PromptText = text;
            SpawnDelayTime = spawntime;
            DestroyDelayTime = destroytime;
            Spawned = false;
        }

        public new int GetType()
        {
            return (int)Type;
        }
    }
    public enum Prompttype{
        UserPrompt = 0,
        AgentPrompt = 1,
        BinaryPrompt = 2,
    }


}
