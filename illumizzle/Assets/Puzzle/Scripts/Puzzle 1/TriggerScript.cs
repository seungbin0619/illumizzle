using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    public GameObject sceneController;

    public int cntTriggerStay = 0;
    public string materialName = null;
    public bool isPreFit = false, isFit = false;

    private void LateUpdate() {
        if (cntTriggerStay > 0 && isPreFit != isFit) {

            JudgeClear judgeClear = sceneController.GetComponent<JudgeClear>();

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
