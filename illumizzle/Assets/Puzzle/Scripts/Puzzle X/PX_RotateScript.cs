using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PX_RotateScript : MonoBehaviour, IDragHandler {

    public GameObject cubeBase;

    private float rotateSpeed = 18;
    public void OnDrag(PointerEventData eventData) {
        if (Input.GetMouseButton(1)) {
            float x = eventData.delta.x * Time.deltaTime * rotateSpeed;
            float y = eventData.delta.y * Time.deltaTime * rotateSpeed;

            transform.Rotate(0, -x, y, Space.World);

            Debug.Log("드래그 중");
        }
    }

    private void Update() {
        if (Input.GetMouseButton(1)) {
            cubeBase.GetComponent<SphereCollider>().enabled = true;
        }
        if (!Input.GetMouseButton(1)) {
            cubeBase.GetComponent<SphereCollider>().enabled = false;
        }
    }
}