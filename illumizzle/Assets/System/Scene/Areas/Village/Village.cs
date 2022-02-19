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
        }

        ActionSystem.instance.Play();
    }

    public void GoWorkroom()
    {
        if (!ActionSystem.instance.IsCompleted) return;

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Walk, 1);

        if (!DataSystem.HasData("Story", "Village.Workroom.00"))
        {
            DataSystem.SetData("Story", "Village.Workroom.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[3]);
        }

        GoScene("Workroom");
    }

    public void GoHome1()
    {
        if (!ActionSystem.instance.IsCompleted) return;

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Walk, 0);

        if (DataSystem.HasData("Story", "Workroom.Blueprint.Check.03") && !DataSystem.HasData("Story", "Village.Home1.01"))
        {
            DataSystem.SetData("Story", "Village.Home1.01", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[6]);

            // ¿¬°á
            if (DataSystem.HasData("Story", "Workroom.Desk.04") &&
                DataSystem.HasData("Story", "Workroom.Power.02") &&
                DataSystem.HasData("Story", "Village.Home1.01"))
            {
                base.GoScene("Map");
                return;
            }
        }
        else
        {
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[4]);
        }

        ActionSystem.instance.Play();
    }

    public void GoHome2()
    {
        if (!ActionSystem.instance.IsCompleted) return;
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Walk, 2);

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[5]);

        ActionSystem.instance.Play();
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
