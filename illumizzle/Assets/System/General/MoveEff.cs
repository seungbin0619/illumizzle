using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveEff : MonoBehaviour
{
    GameObject child;
    UnityEngine.UI.Image image;

    private void Start()
    {
        child = transform.GetChild(0).gameObject;
        image = GetComponent<UnityEngine.UI.Image>();
    }

    public void TriggerMouseEnter(BaseEventData eventData)
    {
        child.SetActive(true);

        image.color = Color.white;
    }

    public void TriggerMouseExit(BaseEventData eventData)
    {
        child.SetActive(false);

        Color col = Color.white;
        col.a = 0.5f;

        image.color = col;
    }
}
