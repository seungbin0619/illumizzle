using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBulb : MonoBehaviour
{
    public RectTransform target;
    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();

        rect.transform.position = target.transform.position;
        rect.sizeDelta = new Vector2(target.rect.width, target.rect.height);
    }
}
