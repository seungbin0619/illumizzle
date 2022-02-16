using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_ColliderScript : MonoBehaviour {

    public GameObject sceneController;

    private P4_JudgeClear judgeClear;
    private GameObject myBlock;
    private P4_BlockScript blockScript;

    private void Start() {
        judgeClear = sceneController.GetComponent<P4_JudgeClear>();

        myBlock = gameObject.transform.parent.gameObject;
        blockScript = myBlock.GetComponent<P4_BlockScript>();
    }

    private void OnTriggerEnter(Collider other) {
        int arrowNum = gameObject.transform.GetSiblingIndex();

        blockScript.isBlocked[arrowNum] += 1;
        //blockScript.isBlocked[arrowNum] = 1;
    }

    private void OnTriggerExit(Collider other) {
        int arrowNum = gameObject.transform.GetSiblingIndex();

        Debug.Log(myBlock.name + " " + other.gameObject.tag);

        blockScript.isBlocked[arrowNum] -= 1;
        //blockScript.isBlocked[arrowNum] = 0;
    }

}
