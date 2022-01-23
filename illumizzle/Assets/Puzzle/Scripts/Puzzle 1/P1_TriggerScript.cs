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
                Debug.Log("��ġ�� Ʈ���� ���� ����");
            }
            else {
                judgeClear.cntFitTrigger -= 1;
                Debug.Log("��ġ�� Ʈ���� ���� ����");
            }
        }

        isPreFit = isFit;
        cntTriggerStay = 0;
    }

}
