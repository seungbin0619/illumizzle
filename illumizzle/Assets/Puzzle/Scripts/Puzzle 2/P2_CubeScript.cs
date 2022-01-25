using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_CubeScript : MonoBehaviour {

    public GameObject sceneController;
    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("group")) {
            P2_GroupScript groupScript = other.GetComponent<P2_GroupScript>();
            if (groupScript.includedCubeCnt < 6) {
                if (gameObject.CompareTag("cube")) {
                    groupScript.includedCube[groupScript.includedCubeCnt++] = gameObject.transform.parent.gameObject;
                }
                else {
                    groupScript.includedCube[groupScript.includedCubeCnt++] = gameObject;
                }
                //groupScript.includedCube[groupScript.includedCubeCnt++] = gameObject.transform.parent.gameObject;
            }
        }
    }
}
