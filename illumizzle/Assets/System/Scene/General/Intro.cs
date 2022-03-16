using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private void Start()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Title");
        ActionSystem.instance.Play();

        DataSystem.Load();
    }
}
