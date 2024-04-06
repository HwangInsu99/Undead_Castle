    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

        d.parentToReturnTo = this.transform;
    }
}
