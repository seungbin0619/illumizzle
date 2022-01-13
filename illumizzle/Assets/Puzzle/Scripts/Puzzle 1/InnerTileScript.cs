using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerTileScript : MonoBehaviour {

    public GameObject sceneController;

    private void OnTriggerStay(Collider other) {
        bool isMooving = sceneController.GetComponent<ExchangeTile>().isMooving;

        if (isMooving == false) {
            TriggerScript triggerScript = other.gameObject.GetComponent<TriggerScript>();
            triggerScript.cntTriggerStay += 1;

            if (triggerScript.cntTriggerStay == 1) {
                triggerScript.materialName = gameObject.GetComponent<MeshRenderer>().material.name;
                Debug.Log("트리거에 메테리얼 등록");
                triggerScript.isFit = true;
            }
            else if (gameObject.GetComponent<MeshRenderer>().material.name != triggerScript.materialName) {
                triggerScript.isFit = false;
                Debug.Log("등록된 메테리얼과 불일치");
            }
        }
    }
}
