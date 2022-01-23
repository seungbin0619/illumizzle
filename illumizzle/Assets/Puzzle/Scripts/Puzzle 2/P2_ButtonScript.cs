using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_ButtonScript : MonoBehaviour {

    public GameObject sceneController;
    public GameObject group;
    public GameObject clickArea;
    public bool isClockwise;

    public bool isRotating = false;
    public Vector3 rotateDir = Vector3.forward;

    P2_ActionController actionController;
    P2_GroupScript groupScript;
    Quaternion target;

    private void Start() {
        actionController = sceneController.GetComponent<P2_ActionController>();
        groupScript = group.GetComponent<P2_GroupScript>();
        clickArea = gameObject.transform.parent.gameObject;
    }

    private void OnMouseDown() {
        if (actionController.isActioning == false) {
            OnMouseExit();

            Debug.Log("버튼 클릭됨");
            actionController.isActioning = true;
            groupScript.buttonScript = gameObject.GetComponent<P2_ButtonScript>();
            group.GetComponent<BoxCollider>().enabled = true;

            if (isClockwise) {
                target = group.transform.rotation * Quaternion.Euler(Vector3.forward * 90);
            }
            else {
                target = group.transform.rotation * Quaternion.Euler(-Vector3.forward * 90);
            }
        }
    }

    private void Update() {
        if (isRotating == true) {

            group.transform.RotateAround(group.transform.position, rotateDir, 300 * Time.deltaTime);

            float angle = Quaternion.Angle(group.transform.rotation, target);

            if (angle < 4f) {
                group.transform.rotation = target;

                groupScript.DeleteChild();
                groupScript.includedCubeCnt = 0;
                isRotating = false;
                actionController.isActioning = false;

                Debug.Log("회전 종료");
            }

        }
    }

    private void OnMouseEnter() {
        clickArea.GetComponent<P2_ClickAreaScript>().isArrowHover = true;
    }

    private void OnMouseExit() {
        clickArea.GetComponent<P2_ClickAreaScript>().isArrowHover = false;
    }
}
