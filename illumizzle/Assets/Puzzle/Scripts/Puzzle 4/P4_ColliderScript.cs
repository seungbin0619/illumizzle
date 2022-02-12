using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_ColliderScript : MonoBehaviour {

    private GameObject myBlock;
    private P4_GroopScript groopScript;

    private void Start() {
        myBlock = gameObject.transform.parent.gameObject;
        groopScript = myBlock.transform.parent.gameObject.GetComponent<P4_GroopScript>();
    }

    private void OnCollisionEnter(Collision collision) {
        int arrowNum = gameObject.transform.GetSiblingIndex();
        int blockNum = myBlock.transform.GetSiblingIndex();
        groopScript.isBlocked[arrowNum][blockNum] = true;
    }

    private void OnCollisionExit(Collision collision) {
        int arrowNum = gameObject.transform.GetSiblingIndex();
        int blockNum = myBlock.transform.GetSiblingIndex();
        groopScript.isBlocked[arrowNum][blockNum] = false;
    }

}
