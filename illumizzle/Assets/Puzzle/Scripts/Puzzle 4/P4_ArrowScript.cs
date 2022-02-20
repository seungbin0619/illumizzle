using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_ArrowScript : MonoBehaviour {

    public GameObject sceneController;

    private P4_JudgeClear judgeClear;
    private GameObject myGroop;
    private P4_GroopScript groopScript;
    private bool isMooving = false;
    private int cntBlocks;

    private GameObject targetObject;
    public Vector3 moveDir;
    private Vector3 targetPosition;

    private GameObject newGroop;

    //private void Awake() {
    //    QualitySettings.vSyncCount = 0;
    //    Application.targetFrameRate = 60;
    //}

    void Start() {
        judgeClear = sceneController.GetComponent<P4_JudgeClear>();
        cntBlocks = judgeClear.cntBlocks;

        myGroop = gameObject.transform.parent.parent.gameObject;
        groopScript = myGroop.GetComponent<P4_GroopScript>();
    }

    private void OnMouseDown() {
        if (judgeClear.isActioning == false) {
            OnMouseExit();

            myGroop.GetComponent<P4_GroopScript>().isArrowHover = false;

            //Debug.Log("그룹 이동 버튼 클릭됨");
            judgeClear.isActioning = true;
            isMooving = true;

            int arrowNum = gameObject.transform.GetSiblingIndex();
            int boundaryIdx = 0; //여기서부터 위 블록들 분리
            for (int i = 0; i < cntBlocks; i++) {
                if (groopScript.isBlocked[arrowNum][i] == 0) {
                    boundaryIdx = i;
                    break;
                }
            }

            //Debug.Log("boundaryIdx : " + boundaryIdx);

            if (boundaryIdx >= 1) { //블록 덩어리 분리해야 하는 경우

                newGroop = Instantiate(myGroop, gameObject.transform.position, gameObject.transform.rotation);

                int childCnt = myGroop.transform.childCount;

                newGroop.transform.parent = myGroop.transform.parent;
                newGroop.transform.localPosition = myGroop.transform.localPosition;
                newGroop.transform.localPosition += Vector3.up * boundaryIdx;
                newGroop.transform.localScale = new Vector3(1, 1, 1);
                newGroop.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

                //새 그룹 아래 블록들 삭제
                for (int i = 1; i < boundaryIdx + 1; i++) {
                    newGroop.transform.GetChild(i).gameObject.SetActive(false);
                    Destroy(newGroop.transform.GetChild(i).gameObject);
                }

                //기존 그룹 위 블록들 삭제, 새 그룹 위 블록들 위치 변경
                for (int i = boundaryIdx + 1; i < childCnt; i++) {
                    newGroop.transform.GetChild(i).transform.localPosition
                        += Vector3.down * (newGroop.transform.GetChild(i).transform.localPosition.y
                        - i + boundaryIdx + 1);

                    myGroop.transform.GetChild(i).gameObject.SetActive(false);
                    Destroy(myGroop.transform.GetChild(i).gameObject);
                }

                targetObject = newGroop;

                int myBlockCnt = boundaryIdx;
                int newBlockCnt = childCnt - boundaryIdx - 1;

                ReSetGroop(myGroop, myBlockCnt);
                ReSetGroop(newGroop, newBlockCnt);

                P4_GroopScript myGroupScript = myGroop.GetComponent<P4_GroopScript>();
                P4_GroopScript newGroupScript = newGroop.GetComponent<P4_GroopScript>();


                //Debug.Log(myBlockCnt + " " + newBlockCnt);

                if (myGroop.transform.localPosition.y == 0 && myBlockCnt == 1) {
                    myGroupScript.isFin = true;
                }

            }
            else {
                targetObject = myGroop;
            }

            targetPosition = targetObject.transform.localPosition + moveDir;
        }
    }

    private void ReSetGroop(GameObject groop, int blockCnt) {
        BoxCollider collider = groop.GetComponent<BoxCollider>();
        collider.size = new Vector3(0.81f, blockCnt + 0.01f, 0.81f);
        collider.center = new Vector3(collider.center.x,
            (blockCnt - 1) / 2.0f, collider.center.z);
        groop.transform.GetChild(0).localPosition = new Vector3(0, blockCnt - 1, 0);
        groop.GetComponent<P4_GroopScript>().cntBlocks = blockCnt;
    }

    void Update() {
        if (isMooving == true) { //그룹 이동
            targetObject.transform.localPosition += moveDir * 3 * Time.deltaTime;

            float dist = Vector3.Distance(targetObject.transform.localPosition, targetPosition);

            if (dist <= Time.deltaTime * 2f) {
                targetObject.transform.localPosition = targetPosition;
                isMooving = false;
                judgeClear.isActioning = false;

                //Debug.Log("이동 종료");
            }
        }

    }

    private void OnMouseEnter() {
        myGroop.GetComponent<P4_GroopScript>().isArrowHover = true;
    }

    private void OnMouseExit() {
        myGroop.GetComponent<P4_GroopScript>().isArrowHover = false;
    }
}
