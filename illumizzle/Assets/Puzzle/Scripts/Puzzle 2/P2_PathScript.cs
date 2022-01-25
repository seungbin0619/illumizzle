using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_PathScript : MonoBehaviour {

    public GameObject sceneController;
    P2_ActionController actionController;

    private void Start() {
        sceneController = gameObject.transform.parent.parent.GetChild(0).gameObject.GetComponent<P2_CubeScript>().sceneController;
        actionController = sceneController.GetComponent<P2_ActionController>();
    }

    private void OnTriggerStay(Collider other) {
        if (actionController.isActioning == false && other.CompareTag("meepleTrigger")) {
            P2_MeepleArrowScript meepleArrowScript = other.transform.parent.gameObject.GetComponent<P2_MeepleArrowScript>();
            meepleArrowScript.cntdTileCnt++;
        }
    }
}
