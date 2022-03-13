using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1_JudgeClear : MonoBehaviour {

    public int cntTotFitTrigger;
    public int cntFitTrigger = 0;
    private bool isFinished = false;

    public int handingCnt = 0;
    public int minHandingCnt = 0;
    public GameObject handingCntText;

    //==================Cheet Key===================
    public string cheatKey = "showmethenextstage";
    public int cheatKeyLen = 18;
    public int cheatKeyIdx = 0;
    private long lastKeyInputTime = 0;
    //==============================================

    private void Start() {
        if (DataSystem.HasData("Story", "LIGHT") == false) {
            handingCntText.SetActive(false);
        }
    }

    void Update() {
        bool debug = false;
#if UNITY_EDITOR
        debug = Input.GetKeyDown(KeyCode.S);
#endif

        if (isFinished == false && (cntFitTrigger == cntTotFitTrigger || cheatKeyIdx == cheatKeyLen || debug)) { 
            isFinished = true;
            
            if (handingCnt <= minHandingCnt && cheatKeyIdx != cheatKeyLen) {
                //AchievementsSystem.instance.ClearAchievement("ACH_MIN_HDL_FOREST");
            }

            SFXSystem.instance.PlaySound(22);
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

        handingCntText.GetComponent<Text>().text = handingCnt.ToString();
    }
}
