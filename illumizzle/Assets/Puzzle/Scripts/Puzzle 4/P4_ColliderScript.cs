using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_ColliderScript : MonoBehaviour {

    public GameObject sceneController;

    private P4_JudgeClear judgeClear;
    private GameObject myBlock;
    private P4_BlockScript blockScript;

    private bool isTriggerEnter = false;

    private void Start() {
        judgeClear = sceneController.GetComponent<P4_JudgeClear>();

        myBlock = gameObject.transform.parent.gameObject;
        blockScript = myBlock.GetComponent<P4_BlockScript>();
    }

    //private void OnTriggerEnter(Collider other) {
    //    int arrowNum = gameObject.transform.GetSiblingIndex();

    //    Debug.Log("충돌 시작 - " + myBlock.name + " " + other.gameObject.tag);

    //    //blockScript.isBlocked[arrowNum] += 1;
    //    blockScript.isBlocked[arrowNum] = 1;
    //}

    //private void OnTriggerExit(Collider other) {
    //    int arrowNum = gameObject.transform.GetSiblingIndex();

    //    Debug.Log("충돌 종료 - " + myBlock.name + " " + other.gameObject.tag);

    //    //blockScript.isBlocked[arrowNum] -= 1;
    //    blockScript.isBlocked[arrowNum] = 0;
    //}

    private void OnTriggerStay(Collider other) {
        isTriggerEnter = true;
    }

    private void FixedUpdate() {
        int arrowNum = gameObject.transform.GetSiblingIndex();
        if (isTriggerEnter == false) {
            blockScript.isBlocked[arrowNum] = 0;
        }
        else { // isTriggerEnter == true
            blockScript.isBlocked[arrowNum] = 1;
            isTriggerEnter = false;
        }
    }


}
