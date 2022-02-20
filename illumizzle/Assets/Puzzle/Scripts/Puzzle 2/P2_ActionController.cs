using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_ActionController : MonoBehaviour {
    public bool isActioning = false;
    public int maxGroupCubeCnt;
    public int meepleCnt;

    //================Rule Displayer================
    public GameObject rule;
    public bool isRuleOn = false;
    //==============================================


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
