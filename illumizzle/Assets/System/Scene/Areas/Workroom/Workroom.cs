using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workroom : Area
{
    protected override void LateStart()
    {
        if (!DataSystem.HasData("Story", "Workroom.Entry.00"))
        {
            DataSystem.SetData("Story", "Workroom.Entry.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
        }

        ActionSystem.instance.Play();
    }

    public void ClickBulb()
    {
        if (!DataSystem.HasData("Story", "Workroom.Bulb.00"))
        {
            DataSystem.SetData("Story", "Workroom.Bulb.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[3]);
        }
        else ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[4]);

        ActionSystem.instance.Play();
    }

    public void ClickBlueprint()
    {
        if (!DataSystem.HasData("Story", "Workroom.Blueprint.00"))
        {
            DataSystem.SetData("Story", "Workroom.Blueprint.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[2]);
        }

        ActionSystem.instance.Play();
    }

    public void ClickWindow()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[14]);
        ActionSystem.instance.Play();
    }

    public void ClickPower()
    {
        if (!DataSystem.HasData("Story", "Workroom.Blueprint.00"))
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[12]);
        else ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[13]);

        ActionSystem.instance.Play();
    }

    public void ClickFloor()
    {
        if (!DataSystem.HasData("Story", "Workroom.Floor.00"))
        {
            DataSystem.SetData("Story", "Workroom.Floor.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[10]);
        }
        else ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[11]);

        ActionSystem.instance.Play();
    }

    public void ClickChair()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[5]);
        ActionSystem.instance.Play();
    }

    public void ClickDesk()
    {
        if (!DataSystem.HasData("Story", "Workroom.Blueprint.00"))
        {
            if (!DataSystem.HasData("Story", "Workroom.Desk.00"))
            {
                DataSystem.SetData("Story", "Workroom.Desk.00", 1);
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[6]);
            }
            else ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[7]);
        }
        else
        {
            if (!DataSystem.HasData("Story", "Workroom.Desk.02"))
            {
                DataSystem.SetData("Story", "Workroom.Desk.02", 1);
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[8]);
            }
            else ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[9]);
        }
        ActionSystem.instance.Play();
    }


    public override void GoScene(string name)
    {
        if (!DataSystem.HasData("Story", "Workroom.Blueprint.00"))
        {
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[1]);
            ActionSystem.instance.Play();

            return;
        }

        base.GoScene(name);
    }
}
