using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P3_BaseRotater : MonoBehaviour, IDragHandler {

    public GameObject sceneController;

    private P3_JudgeClear judgeClear;

    private float rotateSpeed = 0.0016f;
    private bool isRotating = false;

    private long lastOnDragTime = 0;

    private void Start() {
        judgeClear = sceneController.GetComponent<P3_JudgeClear>();
    }

    public void OnDrag(PointerEventData eventData) {
        if (lastOnDragTime != 0) {

            long deltaTime = System.DateTime.Now.Ticks - lastOnDragTime;

            float y = eventData.delta.y * deltaTime * rotateSpeed / Screen.width;

            if (y > 0.5) y = 0.5f;
            if (y <- 0.5) y = -0.5f;
            //Debug.Log(gameObject.transform.rotation.x + " " +  y);

            if (!(gameObject.transform.rotation.x < -0.06 && y > 0) && !(gameObject.transform.rotation.x > 0.20 && y < 0)) {
                transform.Rotate(0, 0, y, Space.World);
                //Debug.Log("드래그 중");
            }
        }

        lastOnDragTime = System.DateTime.Now.Ticks;
    }

    private void Update() {
        if (Input.GetMouseButton(1) && judgeClear.isActioning == false) {
            isRotating = true;
            judgeClear.isActioning = true;
        }
        if (isRotating && !Input.GetMouseButton(1)) {
            isRotating = false;
            judgeClear.isActioning = false;
            lastOnDragTime = 0;
        }
    }

}