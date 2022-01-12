using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaVillage : Area
{
    public TalkBase talk;
    public void TEST()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talk);
        ActionSystem.instance.Play();
    }
}
