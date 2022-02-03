using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_ButtonScript : MonoBehaviour {

    public GameObject targetLine;
    public GameObject sceneController;

    private P3_JudgeClear judgeClear;
    private bool isMooving = false;
    private float moveDir, targetHeight;

    private void Start() {
        judgeClear = sceneController.GetComponent<P3_JudgeClear>();
    }

    private void OnMouseDown() {
        if (judgeClear.isActioning == false) {
            isMooving = true;
            judgeClear.isActioning = true;

            if (targetLine.transform.position.y > judgeClear.maxHeight - 0.5f) {
                moveDir = -2f;
                targetHeight = 0;
            }
            else {
                moveDir = 1f;
                targetHeight = targetLine.transform.position.y + 1;
            }

            Debug.Log("이동 시작");
        }
    }

    private void Update() {
        if (isMooving == true) {

            targetLine.transform.position += Vector3.up * moveDir * 4 * Time.deltaTime;

            float dist = targetLine.transform.position.y - targetHeight;
            if (dist < 0) dist = -dist;

            if (dist <= 0.07f) {
                targetLine.transform.position = new Vector3(targetLine.transform.position.x, 
                    targetHeight, targetLine.transform.position.z);
                isMooving = false;
                judgeClear.isActioning = false;

                Debug.Log("이동 종료");
            }

        }
    }
}
