using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_JudgeClear : MonoBehaviour {

    P2_ActionController actionController;

    public GameObject[] meeples = new GameObject[2];
    public GameObject[] destinations = new GameObject[2];

    private bool isFinished = false;

    //==================Cheet Key===================
    public string cheatKey = "showmethenextstage";
    public int cheatKeyLen = 18;
    public int cheatKeyIdx = 0;
    private long lastKeyInputTime = 0;
    //==============================================

    private void Start() {
        actionController = gameObject.GetComponent<P2_ActionController>();
    }

    void Update() {
        bool debug = false;
#if UNITY_EDITOR
        debug = Input.GetKeyDown(KeyCode.S);
#endif

        bool isArrived = true;

        for (int i = 0; i < actionController.meepleCnt && isArrived; i++) {
            float dist = Vector3.Distance(meeples[i].transform.position, destinations[i].transform.position);
            if (dist > 0.05f) isArrived = false;
        }


        if (isFinished == false && (isArrived == true || cheatKeyIdx == cheatKeyLen || debug)) {
            isFinished = true;

            if (actionController.handingCnt <= actionController.minHandingCnt && cheatKeyIdx != cheatKeyLen) {
#if UNITY_EDITOR
                Debug.Log("ACH_MIN_HDL_ISLAND");
#else
                AchievementsSystem.instance.ClearAchievement("ACH_MIN_HDL_ISLAND");
#endif
            }
            else if (cheatKeyIdx == cheatKeyLen) {
                DataSystem.SetData("Puzzle", "CheatFlag", 1);
            }

            if (actionController.minHandingCnt != -1 && !DataSystem.HasData("Puzzle", "CheatFlag")) {
#if UNITY_EDITOR
                Debug.Log("ACH_NO_CHEATKEY");
#else
                AchievementsSystem.instance.ClearAchievement("ACH_NO_CHEATKEY");
#endif
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

    }
}
