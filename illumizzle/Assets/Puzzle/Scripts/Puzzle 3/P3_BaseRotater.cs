using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class P3_BaseRotater : MonoBehaviour {

    public GameObject sceneController;

    private P3_JudgeClear judgeClear;

    private float rotateSpeed = 30f;
    private bool isRotating = false;
    private float rotateDir = 0, rotateDist = 5f;
    private Quaternion target;

    private void Start() {
        judgeClear = sceneController.GetComponent<P3_JudgeClear>();
        target = transform.rotation;
    }

    private void Update() {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput > 0 && rotateDir >= 0 && transform.localRotation.x >= -0.06) {
            target *= Quaternion.Euler(new Vector3(-rotateDist, 0, 0));
            rotateDir = 1;
            isRotating = true;
            judgeClear.isActioning = true;

        }
        else if (wheelInput < 0 && rotateDir <= 0 && transform.localRotation.x <= 0.20) {
            target *=  Quaternion.Euler(new Vector3(rotateDist, 0, 0));
            rotateDir = -1;
            isRotating = true;
            judgeClear.isActioning = true;
        }

        if (isRotating) {
            transform.RotateAround(transform.position, Vector3.forward, rotateDir * rotateSpeed * Time.deltaTime);

            //Debug.Log(transform.localRotation + "&" + target);

            float angle = transform.localRotation.x - target.x;
            if (angle < 0) angle = -angle;

            if (angle < 0.002f) {
                transform.localRotation = target;

                isRotating = false;
                judgeClear.isActioning = false;
                rotateDir = 0;

                target = gameObject.transform.localRotation;
            }
            else if ((transform.localRotation.x < -0.06 && rotateDir > 0)
                || (transform.localRotation.x > 0.20 && rotateDir < 0)) {

                isRotating = false;
                judgeClear.isActioning = false;
                rotateDir = 0;

                target = gameObject.transform.localRotation;
            }
        }
    }

}