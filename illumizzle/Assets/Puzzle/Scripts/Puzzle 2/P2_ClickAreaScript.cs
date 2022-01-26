using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_ClickAreaScript : MonoBehaviour {

    public GameObject sceneController;

    public GameObject[] arrows = new GameObject[2];
    public int arrowCnt;

    public bool isHover = false;
    public bool isArrowHover = false;
    private bool isArrowOn = false;

    P2_ActionController actionController;

    private void Start() {
        for (int i = 0; i < arrowCnt; i++) {
            arrows[i] = transform.GetChild(i).gameObject;
        }
        actionController = sceneController.GetComponent<P2_ActionController>();
    }

    private void OnMouseEnter() {
        isHover = true;
    }

    private void OnMouseExit() {
        isHover = false;
    }

    private void Update() {
        if (isHover == true && isArrowOn == false
            && actionController.isActioning == false) {

            for (int i = 0; i < arrowCnt; i++) {
                arrows[i].GetComponent<SpriteRenderer>().enabled = true;
                arrows[i].GetComponent<BoxCollider>().enabled = true;

                if (gameObject.CompareTag("meeple")) {
                    if (arrows[i].GetComponent<P2_MeepleArrowScript>().isPathCnnted == false) {
                        arrows[i].GetComponent<SpriteRenderer>().enabled = false;
                        arrows[i].GetComponent<BoxCollider>().enabled = false;
                    }
                }
            }

            isArrowOn = true;
        }

        else if (isHover == false && isArrowHover == false && isArrowOn == true) {

            for (int i = 0; i < arrowCnt; i++) {
                arrows[i].GetComponent<SpriteRenderer>().enabled = false;
                arrows[i].GetComponent<BoxCollider>().enabled = false;
            }

            isArrowOn = false;
        }
    }
}
