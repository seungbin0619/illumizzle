using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Area
{
    private readonly string[] puzzles = new string[5]
    {
        "Stage2-1", "Stage2-2", "Stage2-3", "Stage2-4", "Stage2-5"
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

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Sound, 6);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Walk, index);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 0.5f);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Puzzle, puzzles[index]);

        ActionSystem.instance.Play();
    }

    protected override void LateStart()
    {
        if (!DataSystem.HasData("Story", "Rock.Entry.00"))
        {
            DataSystem.SetData("Story", "Rock.Entry.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
        }
        else if (DataSystem.HasData("Puzzle", puzzles[2]) && !DataSystem.HasData("Story", "Rock.Story.00"))
        {
            DataSystem.SetData("Story", "Rock.Story.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[1]);
        }
        else if (DataSystem.HasData("Puzzle", puzzles[4]) && !DataSystem.HasData("Story", "Rock.Story.01"))
        {
            DataSystem.SetData("Story", "Rock.Story.01", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[2]);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[3]);

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 0.5f);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Workroom");
        }

        ActionSystem.instance.Play();
    }

    public override void GoScene(string name)
    {
        if (!ActionSystem.instance.IsCompleted) return;

        if (!DataSystem.HasData("Story", "Rock.Story.01"))
        {
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[4]);
            ActionSystem.instance.Play();

            return;
        }

        base.GoScene(name);
    }

    public void ClickLight()
    {
        if (ActionSystem.instance.isPlaying) return;

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[5]);
        ActionSystem.instance.Play();
    }

    public void ClickGrass()
    {
        if (ActionSystem.instance.isPlaying) return;

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[6]);
        ActionSystem.instance.Play();
    }
}
