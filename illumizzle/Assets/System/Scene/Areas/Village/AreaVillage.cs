using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaVillage : Area
{
    public TalkBase[] talk;

    protected override void Start()
    {
        base.Start();

        //
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talk[0]);
        ActionSystem.instance.Play();
    }

    public void TEST()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talk[0]);
        ActionSystem.instance.Play();
    }
}
