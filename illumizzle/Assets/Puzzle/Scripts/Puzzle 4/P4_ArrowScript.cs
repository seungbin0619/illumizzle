using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_ArrowScript : MonoBehaviour {

    public GameObject sceneController;

    private P4_JudgeClear judgeClear;
    private GameObject myGroop;
    private P4_GroopScript groopScript;
    private bool isMooving;
    private int cntBlocks;

    private GameObject targetObject;
    public Vector3 moveDir;
    private Vector3 targetPosition;

    private GameObject newGroop;

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

            Debug.Log("��� �̵� ��ư Ŭ����");
            judgeClear.isActioning = true;
            isMooving = true;

            int arrowNum = gameObject.transform.GetSiblingIndex();
            int boundaryIdx = 0; //���⼭���� �� ��ϵ� �и�
            for (int i = 1; i <= cntBlocks && boundaryIdx == 0; i++) {
                if (groopScript.isBlocked[arrowNum][i] == false) {
                    boundaryIdx = i;
                }
            }

            if (boundaryIdx >= 2) { //��� ��� �и��ؾ� �ϴ� ���
                newGroop = Instantiate(myGroop, gameObject.transform.position, gameObject.transform.rotation);

                int childCnt = myGroop.transform.childCount;

                newGroop.transform.parent = myGroop.transform.parent;
                newGroop.transform.localPosition = myGroop.transform.localPosition;
                newGroop.transform.localPosition += Vector3.up * (boundaryIdx - 1);
                newGroop.transform.localScale = new Vector3(1, 1, 1);
                newGroop.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

                //�� �׷� �Ʒ� ��ϵ� ����
                for (int i = 1; i < boundaryIdx; i++) {
                    newGroop.transform.GetChild(i).gameObject.SetActive(false);
                    Destroy(newGroop.transform.GetChild(i).gameObject);
                }

                //���� �׷� �� ��ϵ� ����, �� �׷� �� ��ϵ� ��ġ ����
                for (int i = boundaryIdx; i < childCnt; i++) {
                    newGroop.transform.GetChild(i).transform.localPosition
                        += Vector3.down * (newGroop.transform.GetChild(i).transform.localPosition.y
                        - i + boundaryIdx);

                    myGroop.transform.GetChild(i).gameObject.SetActive(false);
                    Destroy(myGroop.transform.GetChild(i).gameObject);
                }


                targetObject = newGroop;
            }
            else {
                targetObject = myGroop;
            }

            targetPosition = targetObject.transform.localPosition + moveDir;

        }
    }

    void Update() {
        if (isMooving == true) {
            targetObject.transform.localPosition += moveDir * 3 * Time.deltaTime;

            float dist = Vector3.Distance(targetObject.transform.localPosition, targetPosition);

            if (dist < Time.deltaTime * 5f) {
                targetObject.transform.localPosition = targetPosition;
                isMooving = false;
                judgeClear.isActioning = false;

                Debug.Log("�̵� ����");
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
