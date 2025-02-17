using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : Area
{
    private readonly string[] puzzles = new string[5]
    {
        "Stage1-1", "Stage1-2", "Stage1-3", "Stage1-4", "Stage1-5"
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

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Sound, 5);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Walk, index);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 0.5f);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Puzzle, puzzles[index]);

        ActionSystem.instance.Play();
    }

    protected override void LateStart()
    {
        if (!DataSystem.HasData("Story", "LIGHT"))
            SFXSystem.instance.BgmChange(3);
        else SFXSystem.instance.BgmChange(6);

        if (!DataSystem.HasData("Story", "Forest.Entry.00"))
        {
            DataSystem.SetData("Story", "Forest.Entry.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
        }
        else if (DataSystem.HasData("Puzzle", puzzles[2]) && !DataSystem.HasData("Story", "Forest.Story.00"))
        {
            DataSystem.SetData("Story", "Forest.Story.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[1]);
        }
        else if (DataSystem.HasData("Puzzle", puzzles[4]) && !DataSystem.HasData("Story", "Forest.Story.01"))
        {
            DataSystem.SetData("Story", "Forest.Story.01", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[2]);
        }

        ActionSystem.instance.Play();
    }

    public void ClickPond()
    {
        if (ActionSystem.instance.isPlaying) return;

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[3]);
        ActionSystem.instance.Play();
    }

    public void ClickRock()
    {
        if (ActionSystem.instance.isPlaying) return;

        if (DataSystem.GetData("Story", "Forest.Rock.00", 0) < 3)
        {
            DataSystem.SetData("Story", "Forest.Rock.00", DataSystem.GetData("Story", "Forest.Rock.00", 0) + 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[4]);
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("ACH_DSCV_STONE");
#else
            AchievementsSystem.instance.ClearAchievement("ACH_DSCV_STONE");
#endif
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[5]);
        }

        ActionSystem.instance.Play();
    }

    public void ClickTree()
    {
        if (ActionSystem.instance.isPlaying) return;

#if UNITY_EDITOR
        Debug.Log("ACH_DSCV_TREE");
#else
        AchievementsSystem.instance.ClearAchievement("ACH_DSCV_TREE");
#endif
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[6]);
        ActionSystem.instance.Play();
    }
}
