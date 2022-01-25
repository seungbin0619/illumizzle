using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P2_BaseRotater : MonoBehaviour, IDragHandler {

    public GameObject cubeBase;
    public GameObject sceneController;

    P2_ActionController actionController;

    private float rotateSpeed = 70;

    private void Start() {
        actionController = sceneController.GetComponent<P2_ActionController>();
    }

    public void OnDrag(PointerEventData eventData) {
        if (Input.GetMouseButton(1)) {
            float x = eventData.delta.x * Time.deltaTime * rotateSpeed;
            float y = eventData.delta.y * Time.deltaTime * rotateSpeed;

            transform.Rotate(0, -x, y, Space.World);

            Debug.Log("드래그 중");
        }
    }

    private void Update() {
        if (Input.GetMouseButton(1) && actionController.isActioning == false) {
            cubeBase.GetComponent<SphereCollider>().enabled = true;
            actionController.isActioning = true;
        }
        if (!Input.GetMouseButton(1) && cubeBase.GetComponent<SphereCollider>().enabled == true) {
            cubeBase.GetComponent<SphereCollider>().enabled = false;
            actionController.isActioning = false;
        }
    }
}