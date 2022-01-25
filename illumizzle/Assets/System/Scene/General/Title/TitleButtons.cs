using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtons : MonoBehaviour
{
    private static readonly List<TitleButtons> buttons = new List<TitleButtons>();
    private static readonly Color32[] focusedColor = new Color32[2]
    {
        Color.white, new Color32(255, 255, 255, 127)
    };

    [SerializeField]
    private UnityEngine.UI.Image deco;

    public TMPro.TMP_Text text;

    private void Awake()
    {
        if (!buttons.Contains(this)) buttons.Add(this);
    }

    public void TriggerMouseEnter(UnityEngine.EventSystems.BaseEventData ev)
    {
        Focus(this);
    }

    public void TriggerMouseExit(UnityEngine.EventSystems.BaseEventData ev)
    {
        Focus(null);
    }

    public void Focus(TitleButtons obj)
    {
        deco.gameObject.SetActive(obj != null);

        foreach(TitleButtons button in buttons)
        {
            if(button == obj)
            {
                button.text.color = focusedColor[0];

                deco.rectTransform.position = button.transform.position;
            }else button.text.color = focusedColor[1];
        }
    }
}
