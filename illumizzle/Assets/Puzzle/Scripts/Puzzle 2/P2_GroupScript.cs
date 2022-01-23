using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_GroupScript : MonoBehaviour {

    public int includedCubeCnt = 0;
    public GameObject[] includedCube = new GameObject[4];
    public GameObject cubeBase;
    public P2_ButtonScript buttonScript;

    private void LateUpdate() {
        if (includedCubeCnt == 4 && buttonScript.isRotating == false) {
            MakeChild();
            buttonScript.isRotating = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("그룹에 자식 오브젝트 등록 완료 및 회전 시작");
        }
    }

    private void MakeChild() {
        for (int i = 0; i < 4; i++) {
            includedCube[i].transform.parent = gameObject.transform;
        }
    }

    public void DeleteChild() {
        for (int i = 0; i < 4; i++) {
            includedCube[i].transform.parent = cubeBase.transform;
        }
    }
}
