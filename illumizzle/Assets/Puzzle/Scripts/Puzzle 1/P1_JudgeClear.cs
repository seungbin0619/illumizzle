using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_JudgeClear : MonoBehaviour {

    public int cntTotFitTrigger;
    public int cntFitTrigger = 0;
    private bool isFinished = false;

    //==================Cheet Key===================
    public string cheatKey = "showmethenextstage";
    public int cheatKeyLen = 18;
    public int cheatKeyIdx = 0;
    private long lastKeyInputTime = 0;
    //==============================================

    void Update() {
        if (isFinished == false && (cntFitTrigger == cntTotFitTrigger || cheatKeyIdx == cheatKeyLen)) { 
            isFinished = true;
            Debug.Log("ÆÛÁñ Å¬¸®¾î!!");
            //PuzzleSystem.instance.AfterPuzzle(true);
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
}
