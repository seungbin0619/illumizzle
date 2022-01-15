using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Area
{
    protected override void Start()
    {
        base.Start();
    }

    public void GoVillage()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Village");
        ActionSystem.instance.Play();
    }

    public void GoForest()
    {

    }

    public void GoDesert()
    {

    }

    public void GoCoast()
    {

    }
}
