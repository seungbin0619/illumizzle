using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_InnerTileScript : MonoBehaviour {

    public GameObject sceneController;

    private void OnTriggerStay(Collider other) {
        bool isMooving = sceneController.GetComponent<P1_ExchangeTile>().isMooving;

        if (isMooving == false) {
            P1_TriggerScript triggerScript = other.gameObject.GetComponent<P1_TriggerScript>();
            triggerScript.cntTriggerStay += 1;

            if (triggerScript.cntTriggerStay == 1) {
                triggerScript.mtlNameInit = gameObject.GetComponent<MeshRenderer>().material.name[0];
                //Debug.Log("트리거에 메테리얼 등록");
                triggerScript.isFit = true;
            }
            else if (gameObject.GetComponent<MeshRenderer>().material.name[0] != triggerScript.mtlNameInit) {
                triggerScript.isFit = false;
                //Debug.Log("등록된 메테리얼과 불일치");
            }
        }
    }
}
