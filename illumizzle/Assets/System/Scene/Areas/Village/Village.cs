using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Area
{
    protected override void LateStart()
    {
        if (!DataSystem.HasData("Story", "Village.Entry.00"))
        {
            DataSystem.SetData("Story", "Village.Entry.00", 1);
            DataSystem.SetData("Story", "Village.Entry.01", 1);

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[1]);

            ActionSystem.instance.Play();
        }
    }

    public void GoWorkroom()
    {
        if (!DataSystem.HasData("Story", "Village.Workroom.00"))
        {
            DataSystem.SetData("Story", "Village.Workroom.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[3]);
        }

        GoScene("Workroom");
    }

    public override void GoScene(string name)
    {
        if (!DataSystem.HasData("Story", "Village.Workroom.00"))
        {
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[2]);
            ActionSystem.instance.Play();

            return;
        }

        base.GoScene(name);
    }
}
