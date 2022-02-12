using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_ArrowScript : MonoBehaviour {

    public GameObject sceneController;

    private P4_JudgeClear judgeClear;
    private GameObject myGroop;
    private bool isMooving;

    private GameObject targetObject;
    public Vector3 moveDir;
    private Vector3 targetLocation;

    void Start() {
        judgeClear = sceneController.GetComponent<P4_JudgeClear>();
        myGroop = gameObject.transform.parent.gameObject;
    }
    private void OnMouseDown() {
        if (judgeClear.isActioning == false) {
            OnMouseExit();

            myGroop.GetComponent<P2_ClickAreaScript>().isArrowHover = false;

            Debug.Log("말 이동 버튼 클릭됨");
            judgeClear.isActioning = true;
            isMooving = true;



        }
    }

    void Update() {
        //
    }

    private void OnMouseEnter() {
        myGroop.GetComponent<P4_GroopScript>().isArrowHover = true;
    }

    private void OnMouseExit() {
        myGroop.GetComponent<P4_GroopScript>().isArrowHover = false;
    }
}
