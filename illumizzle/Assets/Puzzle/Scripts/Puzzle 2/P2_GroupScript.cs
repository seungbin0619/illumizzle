using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_GroupScript : MonoBehaviour {

    public GameObject sceneController;
    public GameObject cubeBase;
    public P2_ButtonScript buttonScript;

    public GameObject[] includedObj = new GameObject[13];
    public int includedObjCnt = 0;

    P2_ActionController actionController;
    private int maxCubeCnt;

    private void Start() {
        actionController = sceneController.GetComponent<P2_ActionController>();
        maxCubeCnt = actionController.maxGroupCubeCnt;
    }

    private void LateUpdate() {
        if (includedObjCnt >= maxCubeCnt && buttonScript.isRotating == false) {
            MakeChild();
            buttonScript.isRotating = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("그룹에 자식 오브젝트 등록 완료 및 회전 시작");
        }
    }

    private void MakeChild() {
        for (int i = 0; i < includedObjCnt; i++) {
            includedObj[i].transform.parent = gameObject.transform;
        }
    }

    public void DeleteChild() {
        for (int i = 0; i < includedObjCnt; i++) {
            includedObj[i].transform.parent = cubeBase.transform;
        }
    }
}
