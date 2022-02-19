using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map : Area
{
    private readonly string[] puzzles = new string[5]
    {
        "", "Stage1-5", "Stage4-5", "Stage3-5", ""
    };

    private int cnt = 0;

    protected override void Start()
    {
        base.Start();

        #region [ 레벨 활성화 ]

        for (int i = 0; i < puzzles.Length; i++)
        {
            Transform child = bgRect.GetChild(i);
            bool valid = i <= 1 || DataSystem.HasData("Puzzle", puzzles[i - 1]);

            //child.gameObject.SetActive(valid);

            cnt = i;
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
        }else if (DataSystem.HasData("Story", "Workroom.Desk.04") &&
                DataSystem.HasData("Story", "Workroom.Power.02") &&
                DataSystem.HasData("Story", "Village.Home1.01"))
        {
            // 와우~


        }

        ActionSystem.instance.Play();
    }

    public void Go(string name)
    {
        if (System.Array.IndexOf(new string[] { "Village", "Forest", "Desert", "Coast", "Rock" }, name) >= cnt)
        {
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[1]);
        }
        else
        {
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 0.5f);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, name);
        }

        ActionSystem.instance.Play();
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////

    [SerializeField]
    private TMPro.TMP_Text text;

    [SerializeField]
    private MapScroll scroll;

    public void TriggerMouseEnter(int index)
    {
        string descript =
            new string[]
            {
                "마을, 태양이 있는 작은 마을이다.",
                "숲, 가끔 빛나는 물체가 발견된다.",
                "사막, 스스로 움직이는 것 같은 선인장들이 있다.",
                "해변, 잡동사니가 많이 버려져있다.",
                "???"
            }[index];


        text.text = descript;
        text.transform.parent.gameObject.SetActive(true);
    }

    public void TriggerMouseExit()
    {
        text.transform.parent.gameObject.SetActive(false);
    }

    public void OnScroll(BaseEventData e)
    {
        scroll.OnScroll(e);
    }
}
