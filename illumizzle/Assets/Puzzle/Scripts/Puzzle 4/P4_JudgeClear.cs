using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P4_JudgeClear : MonoBehaviour {

    public int cntBlocks;
    public bool isActioning = false;
    public int sizeX, sizeZ;

    public int cntFitBlock = 0;

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

    public int handingCnt = 0;
    public int minHandingCnt = 25;
    public GameObject handingCntText;

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

        if (isFinished == false && (cntBlocks == cntFitBlock || cheatKeyIdx == cheatKeyLen || debug)) {
            isFinished = true;

            if (handingCnt <= minHandingCnt && cheatKeyIdx != cheatKeyLen) {
#if UNITY_EDITOR
                Debug.Log("ACH_MIN_HDL_DESERT");
#else
                AchievementsSystem.instance.ClearAchievement("ACH_MIN_HDL_DESERT");
#endif
            }
            else if (cheatKeyIdx == cheatKeyLen) {
                DataSystem.SetData("Puzzle", "CheatFlag", 1);
            }

            SFXSystem.instance.PlaySound(22);
            PuzzleSystem.instance.AfterPuzzle(true);
        }

        //==================Cheet Key===================
        string str = Input.inputString;
        if (str != "" && isFinished == false) {

            if (System.DateTime.Now.Ticks - lastKeyInputTime > 10000000) { // 1초 이상 경과
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
