using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workroom : Area
{
    protected override void Start()
    {
        base.Start();

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
        ActionSystem.instance.Play();
    }

    public void Bulb()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[1]);
        ActionSystem.instance.Play();
    }

    public void Window()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[2]);
        ActionSystem.instance.Play();
    }
}
