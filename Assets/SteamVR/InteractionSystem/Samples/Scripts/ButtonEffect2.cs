//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonEffect2 : MonoBehaviour
    {
        public Light supLight;
        private int count = 0;
        public GameObject obj;
        public void OnButtonDown(Hand fromHand)
        {
            ColorSelf(Color.cyan);
            fromHand.TriggerHapticPulse(1000);
            count = count + 1;
            if (count % 2 == 0)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
        }

        public void OnButtonUp(Hand fromHand)
        {
            ColorSelf(Color.white);
            count = count + 1;
            if (count % 2 == 0)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }
    }
}