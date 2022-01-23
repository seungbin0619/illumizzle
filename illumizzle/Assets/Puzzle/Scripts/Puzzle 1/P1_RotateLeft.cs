using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_RotateLeft : MonoBehaviour {

    public GameObject cubeBase;
    public GameObject rightButton;
    public bool isRotatingLeft = false;

    Quaternion target;

    private void Start() {
        target = cubeBase.transform.rotation;
    }

    public void MakeLeftRotate() {
        P1_RotateRight rotateRight = rightButton.GetComponent<P1_RotateRight>();

        if (isRotatingLeft == false && rotateRight.isRotatingRight == false) {
            isRotatingLeft = true;
            Debug.Log("�������� ȸ�� ����");
            target = cubeBase.transform.rotation * Quaternion.Euler(0, 90, 0);
        }
    }

    void Update() {
        if (isRotatingLeft) {

            cubeBase.transform.RotateAround(cubeBase.transform.position, Vector3.up, 400 * Time.deltaTime);

            float angle = Quaternion.Angle(cubeBase.transform.rotation, target);
            if (angle < 5f) {
                isRotatingLeft = false;
                Debug.Log("�������� ȸ�� �Ϸ�");
                cubeBase.transform.rotation = target;
            }
        }
    }
}
