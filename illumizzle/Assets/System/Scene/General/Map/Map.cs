using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Area
{
    private readonly string[] puzzles = new string[4]
    {
        "", "Stage1-5", "Stage2-5", "Stage3-5"
    };

    protected override void Start()
    {
        base.Start();

        #region [ 레벨 활성화 ]

        for (int i = 0; i < puzzles.Length; i++)
        {
            Transform child = bgRect.GetChild(i);
            bool valid = i <= 1 || DataSystem.HasData("Puzzle", puzzles[i - 1]);

            child.gameObject.SetActive(valid);
            if (!valid) break;
        }

        #endregion 
    }
    protected override void LateStart()
    {
        if (!DataSystem.HasData("Story", "Map.Entry.00"))
        {
            DataSystem.SetData("Story", "Map.Entry.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
        }

        ActionSystem.instance.Play();
    }

    public void Go(string name)
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, name);
        ActionSystem.instance.Play();
    }
}
