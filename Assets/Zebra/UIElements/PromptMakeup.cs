using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine.UI;

public class PromptMakeup : MonoBehaviour
{

    public SpawnPrompt spawnprompt;
    public Transform BgGrad;
    public Transform Icon;
    public bool BgGrad_Anim = true;
    public int GradAnimAimLeft = 0; // 0 if gradient moving to right, 1 if moving to left

    //VisualElement label = new Label("Type of Icon to Animate");
    public IconType IconT;

    //public int icontype; //zero for circle icon, 1 for bar icon types.
    //Circle Icon Parameters
    public bool IconAnimate_Status = true;
    public float MaxAnim = 700;
    public AnimationCurve IconAnimCurve;

    //Bar Icon Parameters
    public List<GameObject> EachBar;
    public float BarMaxLength = 15;
    public float BarMinLength = 2;




    // Start is called before the first frame update
    void Start()
    {
        BgGrad = this.transform.Find("Backgr/BgGrad");
        Icon = this.transform.Find("Asisticon");
        spawnprompt = this.GetComponent<SpawnPrompt>();

    }

    // Update is called once per frame
    void Update()
    {
        if (BgGrad_Anim && BgGrad != null)
        {
            AnimGradBackgr();
        }
        if (Icon != null && IconAnimate_Status)
            IconAnimate();



        if (spawnprompt != null)
            if (spawnprompt.Done && IconAnimate_Status)
                MaxAnim -= Time.deltaTime * 100;

    }

    void AnimGradBackgr()
    {
        Vector3 pos = BgGrad.localPosition;

        if (GradAnimAimLeft % 2 > 0)
            pos.x = pos.x - 0.1f;
        else
            pos.x = pos.x + 0.1f;

        if (pos.x > 60 || pos.x < -60)
            GradAnimAimLeft++;

        BgGrad.localPosition = pos;
    }

    void IconAnimate()
    {
        if ((int)IconT == 0)
        {
            Icon.Rotate(0, 0, Time.deltaTime * -220 * IconAnimCurve.Evaluate(Time.time));

        }

        else if ((int)IconT == 1)
        {
            if (EachBar.Count == 0)
            {
                for (int i = 0; i < Icon.childCount; i++)
                    EachBar.Add(Icon.GetChild(i).gameObject);
            }
            for (int j = 0; j < Mathf.CeilToInt(EachBar.Count / 2) + 1; j++)
            {
                EachBar[j].GetComponent<RectTransform>().sizeDelta = new Vector2(1.1f, IconAnimCurve.Evaluate(Time.time * 2 + (300 * j)) * 10 % BarMaxLength + BarMinLength);
                EachBar[EachBar.Count - j - 1].GetComponent<RectTransform>().sizeDelta = new Vector2(1.1f, IconAnimCurve.Evaluate(Time.time * 2 + (300 * j)) * 10 % BarMaxLength + BarMinLength);
            }
        }
        if (MaxAnim < 0)
            StaticIcon();
    }

    void StaticIcon()
    {
        IconAnimate_Status = false;
        Icon.localRotation = new Quaternion(0, 0, 0, 0);
    }

    [System.Serializable]
  //  Type type = new Type();

    public enum IconType
    {
        CircleIcon = 0,
        BarIcon = 1

    }
}

