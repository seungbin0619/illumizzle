using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workroom : Area
{
    public void Bulb()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
        ActionSystem.instance.Play();
    }
}
