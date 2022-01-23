using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_TriggerScript : MonoBehaviour {

    public GameObject sceneController;

    public int cntTriggerStay = 0;
    public char mtlNameInit;
    public bool isPreFit = false, isFit = false;

    private void LateUpdate() {
        if (cntTriggerStay > 0 && isPreFit != isFit) {

            P1_JudgeClear judgeClear = sceneController.GetComponent<P1_JudgeClear>();

            if (isFit == true) {
                judgeClear.cntFitTrigger += 1;
                Debug.Log("일치한 트리거 개수 증가");
            }
            else {
                judgeClear.cntFitTrigger -= 1;
                Debug.Log("일치한 트리거 개수 감소");
            }
        }

        isPreFit = isFit;
        cntTriggerStay = 0;
    }

}
