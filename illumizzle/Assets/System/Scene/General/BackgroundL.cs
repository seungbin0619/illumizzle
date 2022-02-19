using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundL : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bgImage = new Sprite[2];

    void Start()
    {
        int index = DataSystem.GetData("Story", "LIGHT", 0);
        GetComponent<UnityEngine.UI.Image>().sprite = bgImage[index];
    }
}
