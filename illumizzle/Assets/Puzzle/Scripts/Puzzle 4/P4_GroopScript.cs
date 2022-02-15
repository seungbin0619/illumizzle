using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_GroopScript : MonoBehaviour {

    public GameObject sceneController;
    public GameObject[] arrows = new GameObject[4];

    private int sizeX, sizeZ;

    private P4_JudgeClear judgeClear;

    public int[][] isBlocked = new int[4][]; // [방향(앞우뒤좌)][블록번호(1~)]
    public int cntBlocks;

    public bool isHover = false;
    public bool isArrowHover = false;
    private bool isArrowOn = false;

    private bool isFalling = false;
    private RaycastHit hit;
    float MaxDistance = 10f;
    private Vector3 targetPosition;

    public bool isFin = false;
    private bool isFit = false;

    void Start() {
        for (int i = 0; i < 4; i++) {
            arrows[i] = transform.GetChild(0).GetChild(i).gameObject;
        }
        judgeClear = sceneController.GetComponent<P4_JudgeClear>();

        for (int i = 0; i < 4; i++) {
            isBlocked[i] = new int[6];
            for (int j = 0; j < 6; j++) {
                isBlocked[i][j] = 0;
            }
        }

        sizeX = judgeClear.sizeX;
        sizeZ = judgeClear.sizeZ;
    }

    private void OnMouseEnter() {
        isHover = true;
    }

    private void OnMouseExit() {
        isHover = false;
    }

    private void Update() {

        //그룹에 마우스 갖다대기
        if (isHover == true && isFin == false && judgeClear.isActioning == false) {

            if (transform.localPosition.x < sizeX - 1 - 0.1) { //Front
                changeEnabled(arrows[0], true);
            }
            if (transform.localPosition.z < sizeZ - 1 - 0.1) { //Right
                changeEnabled(arrows[1], true);
            }
            if (transform.localPosition.x > 0 + 0.1) { //Back
                changeEnabled(arrows[2], true);
            }
            if (transform.localPosition.z > 0 + 0.1) { //Left
                changeEnabled(arrows[3], true);
            }

            for (int i = 0; i < 4; i++) { //가장 위 블록도 못 가는 경우
                if (isBlocked[i][cntBlocks - 1] == 1) {
                    changeEnabled(arrows[i], false);
                }
            }
        }

        //그룹에서 마우스 치우기
        else if (isHover == false && isArrowHover == false || isArrowOn == true || judgeClear.isActioning == true) {

            for (int i = 0; i < 4; i++) {
                changeEnabled(arrows[i], false);
            }

            isArrowOn = false;
        }

        //낙하할 수 있는지 확인
        if (judgeClear.isActioning == false
            && Physics.Raycast(transform.position, -transform.up, out hit, MaxDistance)) {
            GameObject targetObject = hit.collider.gameObject;
            int objectHigh = (int)(targetObject.transform.localPosition.y + 0.1);
            int objectHeight = 1;
            if (targetObject.CompareTag("group")) {
                objectHeight = targetObject.GetComponent<P4_GroopScript>().cntBlocks;
            }

            int upperBound = objectHigh + objectHeight;

            //Debug.Log(targetObject.name + " " + objectHigh + " " + objectHeight);



            if (targetObject.CompareTag("destination")) { //도착지점으로 낙하 가능
                targetPosition =
                    new Vector3(transform.localPosition.x, objectHigh, transform.localPosition.z);

                isFalling = true;
                judgeClear.isActioning = true;

                if (cntBlocks == 1) {
                    isFin = true;
                }

                char myGroopMtl = transform.GetChild(1).GetComponent<MeshRenderer>().material.name[0];
                char myDstnMtl = targetObject.GetComponent<MeshRenderer>().material.name[0];

                //Debug.Log(myGroopMtl + " " + myDstnMtl);

                if (myGroopMtl == myDstnMtl) {
                    isFit = true;
                }
            }
            else if (transform.localPosition.y > upperBound + 0.1) { //일반 블럭 위로 낙하 가능
                targetPosition =
                    new Vector3(transform.localPosition.x, upperBound, transform.localPosition.z);

                isFalling = true;
                judgeClear.isActioning = true;
            }
            else if (transform.localPosition.y - upperBound < 0.1
                && targetObject.CompareTag("group")) { //다른 그룹과 병합

                if (targetObject.GetComponent<P4_GroopScript>().isFin == false) {
                    int targetChildCnt = targetObject.GetComponent<P4_GroopScript>().cntBlocks;
                    int cnt = 0;
                    targetObject.GetComponent<P4_GroopScript>().cntBlocks += cntBlocks;

                    for (int i = 1; i < transform.childCount; i++) {
                        Debug.Log(transform.GetChild(i).name);
                        transform.GetChild(i).transform.localPosition = new Vector3(
                            transform.GetChild(i).transform.localPosition.x,
                            targetChildCnt + cnt++ - 1,
                            transform.GetChild(i).transform.localPosition.z);
                        transform.GetChild(i).parent = targetObject.transform;
                        i--;
                    }

                    Destroy(gameObject);

                    BoxCollider collider = targetObject.GetComponent<BoxCollider>();
                    int blockCnt = targetObject.GetComponent<P4_GroopScript>().cntBlocks;
                    collider.size = new Vector3(0.81f, blockCnt + 0.01f, 0.81f);
                    collider.center = new Vector3(collider.center.x, (blockCnt - 1) / 2.0f, collider.center.z);

                    targetObject.transform.GetChild(0).localPosition = new Vector3(0, blockCnt - 1, 0);
                }
            }
        }

        //낙하하기
        if (isFalling == true) {
            transform.localPosition += Vector3.down * 4 * Time.deltaTime;

            float dist = Vector3.Distance(transform.localPosition, targetPosition);

            if (dist < Time.deltaTime * 5f) {
                transform.localPosition = targetPosition;
                isFalling = false;
                judgeClear.isActioning = false;

                //Debug.Log("낙하 종료");

                if (isFit == true) {
                    judgeClear.cntFitBlock++;
                }
            }
        }
    }

    private void changeEnabled(GameObject arrow, bool isEnabled) {
        arrow.GetComponent<SpriteRenderer>().enabled = isEnabled;
        arrow.GetComponent<BoxCollider>().enabled = isEnabled;
    }
}
