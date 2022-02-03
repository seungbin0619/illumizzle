using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_CheckerScript : MonoBehaviour {

    public GameObject sceneController;
    public GameObject[] targetLines = new GameObject[4];
    public int targetLineCnt = 0;

    private P3_JudgeClear judgeClear;
    private GameObject myTile;
    private GameObject myTrigger;
    private bool isPreFit = false, isFit = false;
    private int targetCnt;

    private void Start() {
        judgeClear = sceneController.GetComponent<P3_JudgeClear>();
    }

    private void OnTriggerStay(Collider other) {
        myTile = other.gameObject;
        targetCnt = int.Parse(myTile.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text);
        gameObject.GetComponent<BoxCollider>().enabled = false;

        myTrigger = myTile.transform.GetChild(2).gameObject;

        if (targetCnt == 0) {
            isPreFit = true; isFit = true;
            judgeClear.cntFitTile++;
            myTile.transform.GetChild(0).gameObject.GetComponent<TextMesh>().color = Color.green;
        }
    }

    void Update() {

        if (myTrigger.GetComponent<BoxCollider>().enabled && targetLineCnt == judgeClear.maxHeight) {
            myTrigger.GetComponent<BoxCollider>().enabled = false;
        }

        if (judgeClear.isActioning == false) {

            int currCnt = 0;
            for (int i = 0; i < judgeClear.maxHeight; i++) {
                if (targetLines[i].transform.localPosition.y >= myTile.transform.localPosition.y - 0.1) {
                    currCnt++;
                }
            }

            if (currCnt == targetCnt) isFit = true;
            else isFit = false;

            if (isPreFit != isFit) {
                if (isFit) {
                    judgeClear.cntFitTile++;
                    myTile.transform.GetChild(0).gameObject.GetComponent<TextMesh>().color = Color.green;
                    Debug.Log("일치한 타일 개수 증가");
                }
                else {
                    judgeClear.cntFitTile--;
                    myTile.transform.GetChild(0).gameObject.GetComponent<TextMesh>().color = Color.black;
                    Debug.Log("일치한 타일 개수 감소");
                }
            }

            isPreFit = isFit;
        }
    }
}
