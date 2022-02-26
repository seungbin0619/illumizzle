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

            if (meepleArrowScript.crColorInit == 'I' || meepleArrowScript.crColorInit == 'W') {
                meepleArrowScript.cntdTileCnt++;
                meepleArrowScript.crColorInit = gameObject.GetComponent<MeshRenderer>().material.name[0];
            }
            else if (gameObject.GetComponent<MeshRenderer>().material.name[0] == 'W') {
                meepleArrowScript.cntdTileCnt++;
            }
            else if (meepleArrowScript.crColorInit 
                == gameObject.GetComponent<MeshRenderer>().material.name[0]) {
                meepleArrowScript.cntdTileCnt++;
            }

            //Debug.Log(gameObject.transform.parent.parent.name);
        }
    }
}
