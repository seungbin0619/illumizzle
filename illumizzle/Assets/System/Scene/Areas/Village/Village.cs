using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Area
{
    protected override void Start()
    {
        base.Start();

        /*
        if (!DataSystem.HasData("Story", "Village.Entry.00"))
        {
            DataSystem.SetData("Story", "Village.Entry.00", 1);

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
            ActionSystem.instance.Play();
        }
        */
    }
}
