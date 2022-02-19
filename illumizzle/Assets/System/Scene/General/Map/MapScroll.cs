using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    private UnityEngine.UI.Image background;
    private RectTransform rect;

    public float horizontalRange;
    public Vector3 currentPosition;

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
        int current = DataSystem.GetData("Setting", "CurrentMap", 0);
        current = current == 4 ? -1 : 1;

        currentPosition = new Vector3(0, horizontalRange * current, 0);
        rect.localPosition = currentPosition;
    }

    public void OnScroll(UnityEngine.EventSystems.BaseEventData e) {
        if (!ActionSystem.instance.IsCompleted) return;
        if (!DataSystem.HasData("Story", "RockOpen")) return;

        float delta = e.currentInputModule.input.mouseScrollDelta.y * scrollRange;

        currentPosition.y = Mathf.Clamp(currentPosition.y - delta, -horizontalRange, horizontalRange);
    }

    private void Update()
    {
        if (DataSystem.HasData("Story", "RockOpen"))
        {
            if(!DataSystem.HasData("Story", "ViewRock2")) {
                rect.localPosition = Vector3.Lerp(rect.localPosition, currentPosition, Time.deltaTime * scrollSpeed);
            }
            if (!ActionSystem.instance.IsCompleted) return;
        }
        else return;

        rect.localPosition = Vector3.Lerp(rect.localPosition, currentPosition, Time.deltaTime * scrollSpeed);
    }
}
