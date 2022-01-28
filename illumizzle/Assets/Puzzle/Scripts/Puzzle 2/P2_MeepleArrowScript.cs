using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_MeepleArrowScript : MonoBehaviour {

    public GameObject sceneController;
    public GameObject meeple;
    public char crColorInit = 'W';

    public bool isPathCnnted = false;
    public int cntdTileCnt = 0;

    public bool isMooving = false;
    public Vector3 moveDir;
    private Vector3 targetDir;

    private GameObject clickArea;
    P2_ActionController actionController;

    Vector3 target;

    private void Start() {
        actionController = sceneController.GetComponent<P2_ActionController>();
        clickArea = gameObject.transform.parent.gameObject;
    }

    private void OnMouseDown() {
        if (actionController.isActioning == false) {
            OnMouseExit();

            meeple.GetComponent<P2_ClickAreaScript>().isArrowHover = false;

            Debug.Log("말 이동 버튼 클릭됨");
            actionController.isActioning = true;
            isMooving = true;

            targetDir = meeple.transform.rotation * moveDir;

            target = meeple.transform.position + targetDir;
        }
    }

    private void Update() {
        if (isMooving == true) {

            meeple.transform.position += targetDir * 4 * Time.deltaTime;

            float dist = Vector3.Distance(meeple.transform.position, target);

            if (dist < 0.05f) {
                meeple.transform.position = target;
                isMooving = false;
                actionController.isActioning = false;

                Debug.Log("이동 종료");
            }

        }
    }

    private void FixedUpdate() {
        if (cntdTileCnt >= 2) isPathCnnted = true;
        else isPathCnnted = false;

        cntdTileCnt = 0;
        crColorInit = 'W';
    }

    private void OnMouseEnter() {
        clickArea.GetComponent<P2_ClickAreaScript>().isArrowHover = true;
    }

    private void OnMouseExit() {
        clickArea.GetComponent<P2_ClickAreaScript>().isArrowHover = false;
    }
}
