using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_JudgeClear : MonoBehaviour {

    public int maxHeight;
    public bool isActioning = false;

    public int cntTotFitTile;
    public int cntFitTile = 0;
    public GameObject clearText; //

    private bool isFinished = false;

    //================Rule Displayer================
    public GameObject rule;
    public bool isRuleOn = false;
    //==============================================

    private void Start() {
        cntTotFitTile = maxHeight * maxHeight * 2;
    }

    void Update() {

        //if (isFinished == false && cntTotFitTile == cntTotFitTile) {
        if (isFinished == false && cntFitTile == cntTotFitTile || Input.GetKeyDown(KeyCode.S)) {
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
