using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_MeepleScript : MonoBehaviour {

    private void OnTriggerStay(Collider other) {
        P2_GroupScript groupScript = other.GetComponent<P2_GroupScript>();
        if (groupScript.includedCubeCnt < 6) {
            groupScript.includedCube[groupScript.includedCubeCnt++] = gameObject;
            //Debug.Log("추가된 오브젝트 : " + gameObject);
        }
    }
}
