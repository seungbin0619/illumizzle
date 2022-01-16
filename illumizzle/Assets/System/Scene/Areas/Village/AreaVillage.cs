using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaVillage : Area
{
    protected override void Start()
    {
        base.Start();

        if (!DataSystem.HasData("Story", "Village.Entry.00"))
        {
            DataSystem.SetData("Story", "Village.Entry.00", 1);

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
            ActionSystem.instance.Play();
        }
    }

    public void TEST()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Workroom");
        ActionSystem.instance.Play();
    }

    public void Homes()
    {
        Random.InitState((int)(Time.time * 1000));
        int rand = Random.Range(1, 4);

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[rand]);
        ActionSystem.instance.Play();
    }
}
