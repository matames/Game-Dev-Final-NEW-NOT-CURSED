using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public string title;
   public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTip.ShowTooltip_Static(title);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTip.HideTooltip_Static();
    }
}
