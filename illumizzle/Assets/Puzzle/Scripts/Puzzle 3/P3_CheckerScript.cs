using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_CheckerScript : MonoBehaviour {

    public GameObject sceneController;

    private P3_JudgeClear judgeClear;
    private GameObject myTile;
    private bool isTarget, isPreFit = false, isFit = false;

    private RaycastHit hit;

    private void Start() {
        judgeClear = sceneController.GetComponent<P3_JudgeClear>();
    }

    private void OnTriggerStay(Collider other) {
        myTile = other.gameObject;
        isTarget = myTile.GetComponent<SpriteRenderer>().enabled;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        if (!isTarget) {
            isPreFit = true; isFit = true;
            judgeClear.cntFitTile++;
        }
    }

    void Update() {
        if (judgeClear.isActioning == false) {
            if (Physics.Raycast(gameObject.transform.position, 
                -gameObject.transform.forward, out hit, 10)
                && hit.transform.gameObject.CompareTag("block")) {

                if (isTarget) isFit = true;
                else isFit = false;
            }
            else {
                if (isTarget) isFit = false;
                else isFit = true;
            }

            if (isPreFit != isFit) {
                if (isFit) {
                    judgeClear.cntFitTile++;
                    Debug.Log("일치한 타일 개수 증가");
                }
                else {
                    judgeClear.cntFitTile--;
                    Debug.Log("일치한 타일 개수 감소");
                }
            }

            isPreFit = isFit;
        }
    }
}
