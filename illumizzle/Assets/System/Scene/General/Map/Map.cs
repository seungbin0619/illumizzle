using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Area
{
    protected override void LateStart()
    {
        if (!DataSystem.HasData("Story", "Map.Entry.00"))
        {
            DataSystem.SetData("Story", "Map.Entry.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
        }

        ActionSystem.instance.Play();
    }

    public void Go(string name)
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, name);
        ActionSystem.instance.Play();
    }
}
