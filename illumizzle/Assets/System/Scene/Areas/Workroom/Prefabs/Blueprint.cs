using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
    public static readonly string[] partsName = new string[3]
    {
        "¹ß±¤Ã¼", "ÀÚ¼®", "Åé´Ï¹ÙÄû"
    };

    public static readonly string[] partsConditions = new string[3]
    {
        "Stage1-5", "Stage4-5", "Stage3-5"
    };

    public static readonly string[] partsSetFlag = new string[3]
    {
        "Parts.Illuminant", "Parts.Magnet", "Parts.Gear"
    };

    void Start()
    {
        for(int i = 0; i < partsName.Length; i++)
        {
            if (!DataSystem.HasData("Story", partsSetFlag[i])) break;

            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public static void SetParts()
    {
        for (int i = 0; i < partsName.Length; i++)
        {
            if (!DataSystem.HasData("Puzzle", partsConditions[i])) continue;
            if (DataSystem.HasData("Story", partsSetFlag[i])) continue;

            DataSystem.SetData("Story", partsSetFlag[i], 1);
        }
    }

    public static void UpdateParts()
    {
        int count = 0;
        for (int i = 0; i < partsName.Length; i++)
        {
            if (!DataSystem.HasData("Puzzle", partsConditions[i])) continue;
            if (DataSystem.HasData("Story", partsSetFlag[i])) continue;

            count++;
        }

        DataSystem.SetData("Story", "ChangedPartsCount", count);
        DataSystem.SetData("Story", "TotalPartsCount", DataSystem.GetData("Story", "TotalPartsCount", 0) + count);
    }
}
