using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderScript : MonoBehaviour {

    private void OnTriggerStay(Collider other) {

        if (!other.gameObject.CompareTag("base")) {
            SphereScript targetScript = other.gameObject.GetComponent<SphereScript>();
            targetScript.adjObjects[targetScript.adjObjectCnt] = gameObject.transform.parent.gameObject;
            targetScript.adjObjectCnt++;

            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
