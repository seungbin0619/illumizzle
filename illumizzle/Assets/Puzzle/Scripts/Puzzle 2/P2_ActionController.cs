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
    public bool isRuleOn = false;
    //==============================================

    public int handingCnt = 0;
    public int minHandingCnt = 16;
    public GameObject handingCntText;

    private void Start() {
        if (DataSystem.HasData("Story", "LIGHT") == false) {
            handingCntText.SetActive(false);
        }
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

    private void Update() {
        handingCntText.GetComponent<Text>().text = handingCnt.ToString();
    }
}
