using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{
    public Camera m_Camera;
    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean m_ClickAction;

    private GameObject m_CurrentObject = null;
    private PointerEventData m_Data = null;


    protected override void Awake()
    {
      base.Awake();

      m_Data = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
      // Reset data, set Camera
        m_Data.Reset();
        m_Data.position = new Vector2(m_Camera.pixelWidth / 2, m_Camera.pixelHeight / 2);

      // RayCast
        eventSystem.RaycastAll(m_Data, m_RaycastResultCache);
        m_Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        m_CurrentObject = m_Data.pointerCurrentRaycast.gameObject;

      // Clear
        m_RaycastResultCache.Clear();


      // Hover
        HandlePointerExitAndEnter(m_Data, m_CurrentObject);


      // Press
        if (m_ClickAction.GetStateDown(m_TargetSource))
          ProcessPress(m_Data);



      // Release
        if (m_ClickAction.GetStateUp(m_TargetSource))
          ProcessRelease(m_Data);



    }

    public PointerEventData GetData()
    {
      return m_Data;
    }

    public void ResetData()
    {
        print("in the reset data");
        // Reset data, set Camera
        m_Data.Reset();
        m_Data.position = new Vector2(m_Camera.pixelWidth / 2, m_Camera.pixelHeight / 2);

        // RayCast
        eventSystem.RaycastAll(m_Data, m_RaycastResultCache);
        m_Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        m_CurrentObject = m_Data.pointerCurrentRaycast.gameObject;

        print("it is nice to see that reset data is done :)");
    }

        private void ProcessPress (PointerEventData data)
    {
      //Set RayCast
        data.pointerPressRaycast = data.pointerCurrentRaycast;


      //CHeck for object hit, get the down handler, call
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(m_CurrentObject, data, ExecuteEvents.pointerDownHandler);


      // if no down handler, try and get click Handler
        if(newPointerPress == null)
          newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);

      // Set Data
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = m_CurrentObject;


    }

    private void ProcessRelease(PointerEventData data)
    {
      //Execute pointer Up
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);


      // Check for click Handler
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);


      // Check if actual
        if(data.pointerPress == pointerUpHandler)
          {
            ExecuteEvents.Execute(data.pointerPress,data, ExecuteEvents.pointerUpHandler);
          }


      // Clear selected gameObject
        eventSystem.SetSelectedGameObject(null);


      //Reset data
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;




    }


}
