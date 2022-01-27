using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P2_BaseRotater : MonoBehaviour, IDragHandler {

    public GameObject cubeBase;
    public GameObject sceneController;

    P2_ActionController actionController;

    private float rotateSpeed = 0.002f;
    private bool isRotating = false;

    private long lastOnDragTime = 0;

    private void Start() {
        actionController = sceneController.GetComponent<P2_ActionController>();
    }

    public void OnDrag(PointerEventData eventData) {
        if (isRotating == true && lastOnDragTime != 0) {

            long deltaTime = System.DateTime.Now.Ticks - lastOnDragTime;

            float x = eventData.delta.x * deltaTime * rotateSpeed / Screen.width;
            float y = eventData.delta.y * deltaTime * rotateSpeed / Screen.width;

            transform.Rotate(0, -x, y, Space.World);

            Debug.Log("드래그 중");
        }

        lastOnDragTime = System.DateTime.Now.Ticks;
    }

    private void Update() {
        if (Input.GetMouseButton(1) && actionController.isActioning == false) {
            cubeBase.GetComponent<SphereCollider>().enabled = true;
            isRotating = true;
            actionController.isActioning = true;
        }
        if (!Input.GetMouseButton(1) && cubeBase.GetComponent<SphereCollider>().enabled == true) {
            cubeBase.GetComponent<SphereCollider>().enabled = false;
            isRotating = false;
            actionController.isActioning = false;
            lastOnDragTime = 0;
        }
    }
}