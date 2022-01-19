using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Area
{
    protected override void Start()
    {
        base.Start();
    }

    public void Go(string name)
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, name);
        ActionSystem.instance.Play();
    }
}
