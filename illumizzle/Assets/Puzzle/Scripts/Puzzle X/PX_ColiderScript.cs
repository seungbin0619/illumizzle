using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PX_ColiderScript : MonoBehaviour {

    private void OnTriggerStay(Collider other) {

        if (!other.gameObject.CompareTag("base")) {
            PX_SphereScript targetScript = other.gameObject.GetComponent<PX_SphereScript>();
            targetScript.adjObjects[targetScript.adjObjectCnt] = gameObject.transform.parent.gameObject;
            targetScript.adjObjectCnt++;

            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
