using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PX_SphereScript : MonoBehaviour {

    public int adjObjectCnt = 0;
    public GameObject[] adjObjects = new GameObject[4] { null, null, null, null };
    public Material whiteMtl, blackMtl;

    private void OnMouseDown() {
        ToggleMtl(gameObject);

        for (int i = 0; i < 4 && adjObjects[i]; i++) {
            ToggleMtl(adjObjects[i]);
        }
    }

    private void ToggleMtl(GameObject targetObj) {
        if (targetObj.GetComponent<MeshRenderer>().material.name[0] == 'W') {
            targetObj.GetComponent<MeshRenderer>().material = blackMtl;
        }
        else {
            targetObj.GetComponent<MeshRenderer>().material = whiteMtl;
        }
    }
}
