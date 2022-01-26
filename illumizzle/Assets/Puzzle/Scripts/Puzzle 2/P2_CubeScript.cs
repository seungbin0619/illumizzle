using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_CubeScript : MonoBehaviour {

    public GameObject sceneController;

    P2_ActionController actionController;
    private int maxObjCnt;

    private void Start() {
        actionController = sceneController.GetComponent<P2_ActionController>();
        maxObjCnt = actionController.maxGroupCubeCnt + actionController.meepleCnt * 2;
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("group")) {
            P2_GroupScript groupScript = other.GetComponent<P2_GroupScript>();
            if (groupScript.includedObjCnt < maxObjCnt) {
                if (gameObject.CompareTag("cube")) {
                    groupScript.includedObj[groupScript.includedObjCnt++] = gameObject.transform.parent.gameObject;
                }
                else {
                    groupScript.includedObj[groupScript.includedObjCnt++] = gameObject;
                }
                //groupScript.includedCube[groupScript.includedCubeCnt++] = gameObject.transform.parent.gameObject;
            }
        }
    }
}
