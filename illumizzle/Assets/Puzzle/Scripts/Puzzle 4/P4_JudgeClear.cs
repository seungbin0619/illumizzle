using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_JudgeClear : MonoBehaviour {

    public int cntBlocks;
    public bool isActioning = false;
    public int sizeX, sizeZ;

    public int cntFitBlock = 0;
    public GameObject clearText; //

    private bool isFinished = false;

    //================Rule Displayer================
    public GameObject rule;
    public bool isRuleOn = false;
    //==============================================

    void Update() {

        if (cntBlocks == cntFitBlock && isFinished == false || Input.GetKeyDown(KeyCode.S)) {
            isFinished = true;
            Debug.Log("ÆÛÁñ Å¬¸®¾î!!");
            clearText.SetActive(true); //
            //PuzzleSystem.instance.AfterPuzzle(true);
        }
    }

    //================Rule Displayer================
    public void DisplayRule() {
        if (isRuleOn == false) {
            rule.SetActive(true);
            isRuleOn = true;
            isActioning = true;
        }
        else {
            rule.SetActive(false);
            isRuleOn = false;
            isActioning = false;
        }
    }
    //==============================================
}
