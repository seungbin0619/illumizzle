using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_RotateLeft : MonoBehaviour {

    public GameObject cubeBase;
    public GameObject rightButton;
    public bool isRotatingLeft = false;

    public float rotateSpeed = 200;

    Quaternion target;

    public AudioSource audioRotateLeft;

    private void Start() {
        target = cubeBase.transform.rotation;
        //audioRotateLeft.Stop();
    }

    public void MakeLeftRotate() {
        P1_RotateRight rotateRight = rightButton.GetComponent<P1_RotateRight>();

        if (isRotatingLeft == false && rotateRight.isRotatingRight == false) {
            isRotatingLeft = true;
            //Debug.Log("왼쪽으로 회전 시작");
            target = cubeBase.transform.rotation * Quaternion.Euler(0, 90, 0);

            //audioRotateLeft.Play();
        }
    }

    void Update() {
        if (isRotatingLeft) {

            cubeBase.transform.RotateAround(cubeBase.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);

            float angle = Quaternion.Angle(cubeBase.transform.rotation, target);
            if (angle < Time.deltaTime * 200.0f) {
                isRotatingLeft = false;
                //Debug.Log("왼쪽으로 회전 완료");
                cubeBase.transform.rotation = target;
            }
        }
    }
}
