using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButtons : MonoBehaviour
{
    [SerializeField]
    private int index = 0;

    public void TriggerMouseEnter(BaseEventData eventData)
    {
        CursorSystem.instance.SetCursor(index);
    }

    public void TriggerMouseExit(BaseEventData eventData)
    {
        CursorSystem.instance.SetCursor(0);
    }
}
