using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2_ActionController : MonoBehaviour {
    public bool isActioning = false;
    public int maxGroupCubeCnt;
    public int meepleCnt;

    //================Rule Displayer================
    public GameObject rule;
    public int isRuleOn = 0;
    //==============================================

    public int handingCnt = 0;
    public int minHandingCnt = 16;
    public GameObject handingCntText;

    private void Start() {
        if (DataSystem.HasData("Story", "LIGHT") == false) {
            handingCntText.SetActive(false);
        }
    }
    private void Update() {
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
