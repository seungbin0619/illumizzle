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
                triggerScript.mtlNameInit = gameObject.GetComponent<MeshRenderer>().material.name[0];
                //Debug.Log("Ʈ���ſ� ���׸��� ���");
                triggerScript.isFit = true;
            }
            else if (gameObject.GetComponent<MeshRenderer>().material.name[0] != triggerScript.mtlNameInit) {
                triggerScript.isFit = false;
                //Debug.Log("��ϵ� ���׸���� ����ġ");
            }
        }
    }
}
