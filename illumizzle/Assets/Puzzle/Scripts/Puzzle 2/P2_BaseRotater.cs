using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P2_BaseRotater : MonoBehaviour {

    public GameObject cubeBase;
    public GameObject sceneController;

    P2_ActionController actionController;

    private float rotateSpeed = 130f;
    private bool isRotating = false;

    private bool isMouseStop = true;
    private Vector2 preMousePos;
    private Vector2 crMousePos;

    private void Start() {
        actionController = sceneController.GetComponent<P2_ActionController>();
    }


    private void FixedUpdate() {
        if (isRotating == true) {
            crMousePos = Input.mousePosition;

            if (isMouseStop == false) {
                float deltaX = crMousePos.x - preMousePos.x;
                float deltaY = crMousePos.y - preMousePos.y;

                float x = deltaX * rotateSpeed / Screen.width;
                float y = deltaY * rotateSpeed / Screen.width;
                //Debug.Log(x + " " + y);
                transform.Rotate(0, -x, y, Space.World);

                if (x == 0 && y == 0) isMouseStop = true;
            }
            else {
                isMouseStop = false;
            }

            preMousePos = crMousePos;
        }
    }

    private void Update() {
        if (Input.GetMouseButton(1) && actionController.isActioning == false) {
            cubeBase.GetComponent<SphereCollider>().enabled = true;
            isRotating = true;
            actionController.isActioning = true;

            Debug.Log("드래그 시작");
        }
        if (!Input.GetMouseButton(1) && cubeBase.GetComponent<SphereCollider>().enabled == true) {
            cubeBase.GetComponent<SphereCollider>().enabled = false;
            isRotating = false;
            actionController.isActioning = false;
            isMouseStop = true;

            Debug.Log("드래그 종료");
        }
    }
}