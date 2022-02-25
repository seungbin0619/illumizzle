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

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < cntBlocks; j++) {
                isBlocked[i][j] = transform.GetChild(j + 1)
                    .gameObject.GetComponent<P4_BlockScript>().isBlocked[i];
            }
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

                P4_GroopScript targetGroupScript = targetObject.GetComponent<P4_GroopScript>();

                if (targetObject.GetComponent<P4_GroopScript>().isFin == false) {
                    int targetChildCnt = targetGroupScript.cntBlocks;
                    targetGroupScript.cntBlocks += cntBlocks;

                    //int cnt = 0;

                    while (transform.childCount > 1) {
                        //Debug.Log(transform.GetChild(i).name);
                        transform.GetChild(1).parent = targetObject.transform;
                    }

                    //for (int i = 1; i < transform.childCount; i++) {
                    //    transform.GetChild(i).parent = targetObject.transform;
                    //    i--;
                    //}

                    Destroy(gameObject);

                    BoxCollider collider = targetObject.GetComponent<BoxCollider>();
                    int blockCnt = targetGroupScript.cntBlocks;
                    collider.center = new Vector3(collider.center.x, blockCnt - 0.6f, collider.center.z);

                    targetObject.transform.GetChild(0).localPosition = new Vector3(0, blockCnt - 1, 0);


                }
            }
        }

        //낙하하기
        if (isFalling == true) {
            float dist = Vector3.Distance(transform.localPosition, targetPosition);

            if (dist < Time.deltaTime * 30f) {
                transform.localPosition += Vector3.down * 8 * Time.deltaTime;
            }
            else {
                transform.localPosition += Vector3.down * 12 * Time.deltaTime;
            }

            if (dist < Time.deltaTime * 5f) {
                SFXSystem.instance.PlaySound(14);

                transform.localPosition = targetPosition;
                isFalling = false;
                judgeClear.isActioning = false;

                //Debug.Log("낙하 종료");

                if (isFit == true) {
                    judgeClear.cntFitBlock++;
                }
            }
        }


        //그룹에 마우스 갖다대기
        if (isHover == true && isFin == false && judgeClear.isActioning == false) {

            if (transform.localPosition.x < sizeX - 1 - 0.1) { //Front
                ChangeEnabled(arrows[0], true);
            }
            if (transform.localPosition.z < sizeZ - 1 - 0.1) { //Right
                ChangeEnabled(arrows[1], true);
            }
            if (transform.localPosition.x > 0 + 0.1) { //Back
                ChangeEnabled(arrows[2], true);
            }
            if (transform.localPosition.z > 0 + 0.1) { //Left
                ChangeEnabled(arrows[3], true);
            }

            for (int i = 0; i < 4; i++) { //가장 위 블록도 못 가는 경우
                if (isBlocked[i][cntBlocks - 1] >= 1) {
                    ChangeEnabled(arrows[i], false);
                }
            }
        }

        //그룹에서 마우스 치우기
        else if (isHover == false && isArrowHover == false || judgeClear.isActioning == true) {

            for (int i = 0; i < 4; i++) {
                ChangeEnabled(arrows[i], false);
            }
        }

    }

    public void ChangeEnabled(GameObject arrow, bool isEnabled) { //
        arrow.GetComponent<SpriteRenderer>().enabled = isEnabled;
        arrow.GetComponent<BoxCollider>().enabled = isEnabled;
    }
}
