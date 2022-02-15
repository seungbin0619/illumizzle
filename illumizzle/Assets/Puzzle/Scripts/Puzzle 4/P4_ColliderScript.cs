using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_ColliderScript : MonoBehaviour {

    public GameObject sceneController;

    private P4_JudgeClear judgeClear;
    private GameObject myBlock;
    private P4_GroopScript groopScript;

    private void Start() {
        judgeClear = sceneController.GetComponent<P4_JudgeClear>();

        myBlock = gameObject.transform.parent.gameObject;
        groopScript = myBlock.transform.parent.gameObject.GetComponent<P4_GroopScript>();
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log(other.gameObject.name);
        int arrowNum = gameObject.transform.GetSiblingIndex();
        int blockNum = myBlock.transform.GetSiblingIndex() - 1;
        groopScript.isBlocked[arrowNum][blockNum] += 1;
        //Debug.Log("OnCollisionEnter »£√‚µ ");
    }

    private void OnTriggerExit(Collider other) {
        int arrowNum = gameObject.transform.GetSiblingIndex();
        int blockNum = myBlock.transform.GetSiblingIndex() - 1;
        groopScript.isBlocked[arrowNum][blockNum] -= 1;
        //Debug.Log("OnCollisionExit »£√‚µ ");
    }

}
