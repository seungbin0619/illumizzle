using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_RotateRight : MonoBehaviour {

    public GameObject cubeBase;
    public GameObject leftButton;
    public bool isRotatingRight = false;

    public float rotateSpeed = 200;

    Quaternion target;

    public AudioSource audioRotateRight;

    private void Start() {
        target = cubeBase.transform.rotation;
        //audioRotateRight.Stop();
    }

    public void MakeRightRotate() {
        P1_RotateLeft rotateLeft = leftButton.GetComponent<P1_RotateLeft>();

        if (isRotatingRight == false && rotateLeft.isRotatingLeft == false) {
            isRotatingRight = true;
            //Debug.Log("오른쪽으로 회전 시작");
            target = cubeBase.transform.rotation * Quaternion.Euler(0, -90, 0);

            //audioRotateRight.Play();
        }
    }

    void Update() {
        if (isRotatingRight) {

            cubeBase.transform.RotateAround(cubeBase.transform.position, -Vector3.up, rotateSpeed * Time.deltaTime);

            float angle = Quaternion.Angle(cubeBase.transform.rotation, target);
            if (angle < Time.deltaTime * 200.0f) {
                isRotatingRight = false;
                //Debug.Log("오른쪽으로 회전 완료");
                cubeBase.transform.rotation = target;
            }
        }
    }
}
