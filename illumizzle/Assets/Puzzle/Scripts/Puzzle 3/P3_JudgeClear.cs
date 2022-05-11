using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P3_JudgeClear : MonoBehaviour {

    public int maxHeight;
    public bool isActioning = false;

    public int cntTotFitTile;
    public int cntFitTile = 0;

    private bool isFinished = false;

    //================Rule Displayer================
    public GameObject rule;
    public int isRuleOn = 0;
    //==============================================

    //==================Cheet Key===================
    public string cheatKey = "showmethenextstage";
    public int cheatKeyLen = 18;
    public int cheatKeyIdx = 0;
    private long lastKeyInputTime = 0;
    //==============================================

    public int handingCnt = 0;
    public int minHandingCnt = 27;
    public GameObject handingCntText;

    private void Start() {
        cntTotFitTile = maxHeight * maxHeight * 2;
        if (DataSystem.HasData("Story", "LIGHT") == false) {
            handingCntText.SetActive(false);
        }
    }

    void Update() {
        bool debug = false;
#if UNITY_EDITOR
        debug = Input.GetKeyDown(KeyCode.S);
#endif

        if (isFinished == false && (cntFitTile == cntTotFitTile || cheatKeyIdx == cheatKeyLen || debug)) {
            isFinished = true;

#if UNITY_EDITOR
            Debug.Log("ÆÛÁñ Å¬¸®¾î!");
#endif

            if (handingCnt <= minHandingCnt && cheatKeyIdx != cheatKeyLen) {
#if UNITY_EDITOR
                Debug.Log("ACH_MIN_HDL_COAST"); 
#else 
                AchievementsSystem.instance.ClearAchievement("ACH_MIN_HDL_COAST");
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

        //================Rule Displayer================
        if (Input.GetMouseButtonUp(0) && isRuleOn == 2) {
            ConcealRule();
        }
        if (isRuleOn == 1) isRuleOn = 2;
        //==============================================
    }

    //================Rule Displayer================
    public void DisplayRule() {
        if (isRuleOn == 0) {
            rule.SetActive(true);
            isRuleOn = 1;
            isActioning = true;
            SFXSystem.instance.PlaySound(8);
        }
    }

    public void ConcealRule() {
        rule.SetActive(false);
        isRuleOn = 0;
        isActioning = false;
        SFXSystem.instance.PlaySound(9);
    }
    //==============================================

}
