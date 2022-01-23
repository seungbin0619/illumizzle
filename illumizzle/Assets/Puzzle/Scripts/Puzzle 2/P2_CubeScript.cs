using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_CubeScript : MonoBehaviour {

    private void OnTriggerStay(Collider other) {
        P2_GroupScript groupScript = other.GetComponent<P2_GroupScript>();
        groupScript.includedCube[groupScript.includedCubeCnt++] = gameObject;
    }

}
