using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_LineScript : MonoBehaviour {

    public GameObject sceneController;

    private P3_JudgeClear judgeClear;

    private void Start() {
        judgeClear = sceneController.GetComponent<P3_JudgeClear>();
    }

    private void OnTriggerStay(Collider other) {
        //Debug.Log("라인에서 트리거 감지됨");
        P3_CheckerScript checkerScript = other.gameObject.transform.parent.GetChild(1).gameObject.GetComponent<P3_CheckerScript>();
        if (checkerScript.targetLineCnt < judgeClear.maxHeight) {
            checkerScript.targetLines[checkerScript.targetLineCnt++] = gameObject;
        }
        //gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
