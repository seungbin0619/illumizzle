using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_ButtonScript : MonoBehaviour {

    public GameObject targetLine;
    public GameObject sceneController;

    private P3_JudgeClear judgeClear;
    private bool isMooving = false, isOver = false;
    private float moveDir, targetHeight;

    //private void Awake() {
    //    QualitySettings.vSyncCount = 0;
    //    Application.targetFrameRate = 60;
    //}

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
                if (targetLine.transform.localPosition.y < judgeClear.maxHeight - 0.5f) {
                    isMooving = true;
                    judgeClear.handingCnt++;
                    judgeClear.isActioning = true;
                    moveDir = 1f;
                    targetHeight = targetLine.transform.localPosition.y + 1;

                    SFXSystem.instance.PlaySound(18);
                }
            }
            else if (Input.GetMouseButton(1)) {
                if (targetLine.transform.localPosition.y > 0.5f) {
                    isMooving = true;
                    judgeClear.handingCnt++;
                    judgeClear.isActioning = true;
                    moveDir = -1f;
                    targetHeight = targetLine.transform.localPosition.y - 1;

                    SFXSystem.instance.PlaySound(19);
                }
            }
        }


        if (isMooving == true) {

            targetLine.transform.localPosition += Vector3.up * moveDir * 4 * Time.deltaTime;

            float dist = targetLine.transform.localPosition.y - targetHeight;
            if (dist < 0) dist = -dist;

            if (dist <= Time.deltaTime * 3f) {
                targetLine.transform.localPosition = new Vector3(targetLine.transform.localPosition.x, 
                    targetHeight, targetLine.transform.localPosition.z);
                isMooving = false;
                judgeClear.isActioning = false;

                //Debug.Log("이동 종료");
            }

        }
    }
}
