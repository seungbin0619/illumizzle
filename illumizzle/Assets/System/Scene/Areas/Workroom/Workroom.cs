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
        else if(DataSystem.HasData("Story", "Rock.Story.01")) 
        {
            if (!DataSystem.HasData("Story", "Workroom.Entry.01"))
            {
                DataSystem.SetData("Story", "Workroom.Entry.01", 1);
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[24]);
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 1.5f);
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Ending");
            }
            else if (!DataSystem.HasData("Story", "Workroom.Entry.02"))
            {
                DataSystem.SetData("Story", "Workroom.Entry.02", 1);
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[25]);
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[26]);
            }
        }

        ActionSystem.instance.Play();
    }

    public void ClickBlueprint()
    {
        if (!DataSystem.HasData("Story", "Workroom.Blueprint.00"))
        {
            DataSystem.SetData("Story", "Workroom.Blueprint.00", 1);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[2]);
        }else if(!DataSystem.HasData("Story", "Map.Entry.00"))
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[15]);
        else
        {
            Blueprint.UpdateParts();
            int changedCount = DataSystem.GetData("Story", "ChangedPartsCount", 0);
            int totalParts = DataSystem.GetData("Story", "TotalPartsCount", 0);

            if (changedCount == 0) // 구한 부품이 없는 경우
            {
                talks[18].scripts[0].text = "(현재 부품을 " + totalParts + "개 모았다.)";
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[18]);

                if (DataSystem.HasData("Story", "Workroom.Blueprint.Check.03"))
                {
                    ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[20]);
                }
            }
            else
            {
                talks[16].scripts[0].text = "가져온 부품 " + changedCount + "개를 바꿔보자!";
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[16]);

                if (totalParts < Blueprint.partsName.Length)
                {
                    bool firstFlag = false;

                    talks[17].scripts[1].text = "남은게 ";
                    for (int i = 0; i < Blueprint.partsName.Length; i++)
                    {
                        if (i < totalParts) continue;
                        if (firstFlag) talks[17].scripts[1].text += ", ";

                        talks[17].scripts[1].text += Blueprint.partsName[i];
                        firstFlag = true;
                    }

                    talks[17].scripts[1].text += "지? 남은 부품도 빨리 찾으러 가자!";
                    ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[17]);
                }
                else if (!DataSystem.HasData("Story", "Workroom.Blueprint.Check.03"))// 부품 다 구한 경우
                {
                    DataSystem.SetData("Story", "Workroom.Blueprint.Check.03", 1);

                    ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[19]);
                    ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[20]);
                }
            }
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

    public void ClickWindow()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[14]);
        ActionSystem.instance.Play();
    }

    public void ClickPower()
    {
        if (!DataSystem.HasData("Story", "Workroom.Blueprint.Check.03"))
        {
            if (!DataSystem.HasData("Story", "Workroom.Blueprint.00"))
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[12]);
            else ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[13]);
        }else if(DataSystem.HasData("Story", "Workroom.Desk.02") || DataSystem.HasData("Story", "Workroom.Desk.04"))
        {
            if (!DataSystem.HasData("Story", "Workroom.Power.02"))
            {
                DataSystem.SetData("Story", "Workroom.Power.02", 1);
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[22]);

                // 연결
                if (DataSystem.HasData("Story", "Workroom.Desk.04") &&
                    DataSystem.HasData("Story", "Workroom.Power.02") &&
                    DataSystem.HasData("Story", "Village.Home1.01"))
                {
                    base.GoScene("Coast");
                    return;
                }
            }
            else ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[23]);
        }
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
        if (!DataSystem.HasData("Story", "Workroom.Blueprint.Check.03"))
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
        }else
        {
            if (!DataSystem.HasData("Story", "Workroom.Desk.04"))
            {
                DataSystem.SetData("Story", "Workroom.Desk.04", 1);
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, talks[21]);

                // 연결
                if (DataSystem.HasData("Story", "Workroom.Desk.04") &&
                    DataSystem.HasData("Story", "Workroom.Power.02") &&
                    DataSystem.HasData("Story", "Village.Home1.01"))
                {
                    base.GoScene("Coast");
                    return;
                }
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
