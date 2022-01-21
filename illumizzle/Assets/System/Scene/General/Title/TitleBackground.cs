using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackground : MonoBehaviour
{
    [SerializeField]
    private Sprite[] images;
    private UnityEngine.UI.Image background;

    private void Awake()
    {
        background = GetComponent<UnityEngine.UI.Image>();
        //background.material.SetFloat("_Size", 2);
    }

    private void Start()
    {
        int index = DataSystem.GetData("Setting", "CurrentMap", 0);
        background.sprite = images[index];
    }
}
