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

        #region [ ���� Ȱ��ȭ ]

        for (int i = 0; i < puzzles.Length; i++)
        {
            //Transform child = bgRect.GetChild(i);
            bool valid = i <= 1 || DataSystem.HasData("Puzzle", puzzles[i - 1]);

            //child.gameObject.SetActive(valid);

            cnt = i;
            if (!valid) break;
        }

        #endregion 
    }
    protected override void LateStart()
    {
        if (!DataSystem.HasData("Story", "LIGHT"))
            SFXSystem.instance.BgmChange(0);
        else { }

        if (!DataSystem.HasData("Story", "Map.Entry.00"))
        {
            DataSystem.SetData("Story", "Map.Entry.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[0]);
        }else if(DataSystem.HasData("Story", "RockOpen") && !DataSystem.HasData("Story", "ViewRock"))
        {
            DataSystem.SetData("Story", "ViewRock", 1);

            IEnumerator CoView()
            {
                scroll.currentPosition = new Vector3(0, -scroll.horizontalRange, 0);
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[2]);

                yield return new WaitForSeconds(1);
                GoScene("Coast");
            }
            StartCoroutine(CoView());
            return;
        }

        ActionSystem.instance.Play();
    }

    public void Go(string name)
    {
        if (DataSystem.HasData("Story", "ViewRock2")) cnt = 6;

        int index = System.Array.IndexOf(new string[] { "Village", "Forest", "Desert", "Coast", "Rock" }, name);
        if (index >= cnt)
        {
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[1]);
        }
        else
        {
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Sound, 
                new int[] { 3, 5, 3, 3, 6 }[index]);
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
                "����, �¾��� �ִ� ���� �����̴�.",
                "��, ���� ������ ��ü�� �߰ߵȴ�.",
                "�縷, ������ �����̴� �� ���� ��������� �ִ�.",
                "�غ�, �⵿��ϰ� ���� �������ִ�.",
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
