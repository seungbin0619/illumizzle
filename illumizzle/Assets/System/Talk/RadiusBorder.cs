using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusBorder : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    private void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    void Start()
    {
        //Debug.Log(image.rectTransform.rect);
        //Debug.Log(image.sprite.rect);

        image.pixelsPerUnitMultiplier = image.sprite.rect.height / image.rectTransform.rect.height;
    }
}
