using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_RotateRight : MonoBehaviour {

    public GameObject cubeBase;
    public GameObject leftButton;
    public bool isRotatingRight = false;

    public float rotateSpeed = 400;

    Quaternion target;

    private void Start() {
        target = cubeBase.transform.rotation;
    }

    public void MakeRightRotate() {
        P1_RotateLeft rotateLeft = leftButton.GetComponent<P1_RotateLeft>();

        if (isRotatingRight == false && rotateLeft.isRotatingLeft == false) {
            isRotatingRight = true;
            //Debug.Log("���������� ȸ�� ����");
            target = cubeBase.transform.rotation * Quaternion.Euler(0, -90, 0);
        }
    }

    void Update() {
        if (isRotatingRight) {

            cubeBase.transform.RotateAround(cubeBase.transform.position, -Vector3.up, rotateSpeed * Time.deltaTime);

            float angle = Quaternion.Angle(cubeBase.transform.rotation, target);
            if (angle < 5f * Time.deltaTime * 180) {
                isRotatingRight = false;
                //Debug.Log("���������� ȸ�� �Ϸ�");
                cubeBase.transform.rotation = target;
            }
        }
    }
}
