using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_JudgeClear : MonoBehaviour {

    public int maxHeight;
    public bool isActioning = false;

    public int cntTotFitTile;
    public int cntFitTile = 0;
   // public GameObject clearText;

    private bool isFinished = false;

    //================Rule Displayer================
    public GameObject rule;
    public bool isRuleOn = false;
    //==============================================

    //==================Cheet Key===================
    public string cheatKey = "showmethenextstage";
    public int cheatKeyLen = 18;
    public int cheatKeyIdx = 0;
    private long lastKeyInputTime = 0;
    //==============================================

    private void Start() {
        cntTotFitTile = maxHeight * maxHeight * 2;
    }

    void Update() {
        bool debug = false;
#if UNITY_EDITOR
        debug = Input.GetKeyDown(KeyCode.S);
#endif

        if (isFinished == false && (cntFitTile == cntTotFitTile || cheatKeyIdx == cheatKeyLen || debug)) {
            isFinished = true;
            Debug.Log("ÆÛÁñ Å¬¸®¾î!!");
            //clearText.SetActive(true); //
            PuzzleSystem.instance.AfterPuzzle(true);
        }

        //==================Cheet Key===================
        string str = Input.inputString;
        if (str != "" && isFinished == false) {

            if (System.DateTime.Now.Ticks - lastKeyInputTime > 10000000) {
                cheatKeyIdx = 0;
            }

            int len = str.Length;
            for (int i = 0; i < len; i++) {
                if (str[i] == cheatKey[cheatKeyIdx]) {
                    cheatKeyIdx++;
                }
                else if (str[i] == 's') {
                    cheatKeyIdx = 1;
                }
                else {
                    cheatKeyIdx = 0;
                }
            }

            lastKeyInputTime = System.DateTime.Now.Ticks;
        }
        //==============================================
    }

    //================Rule Displayer================
    public void DisplayRule() {
        if (isRuleOn == false) {
            rule.SetActive(true);
            isRuleOn = true;
            isActioning = true;
            SFXSystem.instance.PlaySound(8);
        }
        else {
            rule.SetActive(false);
            isRuleOn = false;
            isActioning = false;
            SFXSystem.instance.PlaySound(9);
        }
    }
    //==============================================

}
