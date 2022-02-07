using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_ButtonScript : MonoBehaviour {

    public GameObject targetLine;
    public GameObject sceneController;

    private P3_JudgeClear judgeClear;
    private bool isMooving = false, isOver = false;
    private float moveDir, targetHeight;

    private void Start() {
        judgeClear = sceneController.GetComponent<P3_JudgeClear>();
    }

    private void OnMouseEnter() {
        isOver = true;
    }

    private void OnMouseExit() {
        isOver = false;
    }

    private void Update() {

        if (isOver && isMooving == false) {
            if (Input.GetMouseButton(0)) {
                isMooving = true;
                judgeClear.isActioning = true;

                if (targetLine.transform.localPosition.y < judgeClear.maxHeight - 0.5f) {
                    moveDir = 1f;
                    targetHeight = targetLine.transform.localPosition.y + 1;
                    Debug.Log("이동 시작");
                }
            }
            else if (Input.GetMouseButton(1)) {
                isMooving = true;
                judgeClear.isActioning = true;

                if (targetLine.transform.localPosition.y > 0.5f) {
                    moveDir = -1f;
                    targetHeight = targetLine.transform.localPosition.y - 1;
                    Debug.Log("이동 시작");
                }
            }
        }


        if (isMooving == true) {

            targetLine.transform.localPosition += Vector3.up * moveDir * 4 * Time.deltaTime;

            float dist = targetLine.transform.localPosition.y - targetHeight;
            if (dist < 0) dist = -dist;

            if (dist <= 0.07f * Time.deltaTime * 180) {
                targetLine.transform.localPosition = new Vector3(targetLine.transform.localPosition.x, 
                    targetHeight, targetLine.transform.localPosition.z);
                isMooving = false;
                judgeClear.isActioning = false;

                Debug.Log("이동 종료");
            }

        }
    }
}
