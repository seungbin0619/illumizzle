using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coast : Area
{
    private readonly string[] puzzles = new string[5]
    {
        "Stage3-1", "Stage3-2", "Stage3-3", "Stage3-4", "Stage3-5"
    };

    protected override void Start()
    {
        base.Start();

        #region [ 레벨 활성화 ]

        for (int i = 0; i < puzzles.Length; i++)
        {
            Transform child = bgRect.GetChild(i);
            bool valid = i == 0 || DataSystem.HasData("Puzzle", puzzles[i - 1]);

            child.gameObject.SetActive(valid);
            if (!valid) break;
        }

        #endregion 
    }

    public void LoadPuzzle(int index)
    {
        if (ActionSystem.instance.isPlaying) return;

        #region [ 퍼즐 시작 전 ]
        switch (index)
        {
            case 0: break;
            case 1: break;
            case 2: break;
            case 3: break;
            case 4: break;
        }
        #endregion

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Sound, 3);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Walk, index);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 0.5f);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Puzzle, puzzles[index]);

        ActionSystem.instance.Play();
    }

    protected override void LateStart()
    {
        if (!DataSystem.HasData("Story", "LIGHT"))
            SFXSystem.instance.BgmChange(5);
        else { }

        if (!DataSystem.HasData("Story", "Coast.Entry.00"))
        {
            DataSystem.SetData("Story", "Coast.Entry.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
        }
        else if (DataSystem.HasData("Puzzle", puzzles[2]) && !DataSystem.HasData("Story", "Coast.Story.00"))
        {
            DataSystem.SetData("Story", "Coast.Story.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[1]);
        }
        else if (DataSystem.HasData("Puzzle", puzzles[4]) && !DataSystem.HasData("Story", "Coast.Story.01"))
        {
            DataSystem.SetData("Story", "Coast.Story.01", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[2]);
        }else if (DataSystem.HasData("Story", "Workroom.Desk.04") &&
                DataSystem.HasData("Story", "Workroom.Power.02") &&
                DataSystem.HasData("Story", "Village.Home1.01") &&
                !DataSystem.HasData("Story", "RockOpen"))
        {
            DataSystem.SetData("Story", "RockOpen", 1);

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[5]);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 0.5f);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Map");

            ActionSystem.instance.Play();

            //
            return;
        }else if(DataSystem.HasData("Story", "ViewRock") && !DataSystem.HasData("Story", "ViewRock2"))
        {
            DataSystem.SetData("Story", "ViewRock2", 1);

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[6]);
        }

        ActionSystem.instance.Play();
    }

    public void ClickTree()
    {
        if (ActionSystem.instance.isPlaying) return;

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[3]);
        ActionSystem.instance.Play();
    }

    public void ClickStack()
    {
        if (ActionSystem.instance.isPlaying) return;

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[4]);
        ActionSystem.instance.Play();
    }
}
