using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    private UnityEngine.UI.Image background;
    private RectTransform rect;

    private float horizontalRange;
    private Vector3 currentPosition;

    private const float scrollRange = 100f;
    private const float scrollSpeed = 3f;

    private void Awake()
    {
        background = GetComponent<UnityEngine.UI.Image>();
        rect = background.rectTransform;
    }

    private void Start()
    {
        horizontalRange = rect.sizeDelta.y * 0.5f;

        currentPosition = rect.localPosition  = new Vector3(0, horizontalRange, 0);
    }

    public void OnScroll(UnityEngine.EventSystems.BaseEventData e) {
        float delta = e.currentInputModule.input.mouseScrollDelta.y * scrollRange;

        currentPosition.y = Mathf.Clamp(currentPosition.y - delta, -horizontalRange, horizontalRange);
    }

    private void Update()
    {
        rect.localPosition = Vector3.Lerp(rect.localPosition, currentPosition, Time.deltaTime * scrollSpeed);
    }
}
