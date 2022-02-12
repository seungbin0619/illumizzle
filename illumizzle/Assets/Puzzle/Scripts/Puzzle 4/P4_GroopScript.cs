using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_GroopScript : MonoBehaviour {

    public GameObject sceneController;
    public GameObject[] arrows = new GameObject[4];

    private P4_JudgeClear judgeClear;

    public bool[][] isBlocked = new bool[4][]; // [방향(앞우뒤좌)][블록번호(1~)]
    private int cntBlocks;

    public bool isHover = false;
    public bool isArrowHover = false;
    private bool isArrowOn = false;

    void Start() {
        for (int i = 0; i < 4; i++) {
            arrows[i] = transform.GetChild(0).GetChild(i).gameObject;
        }
        judgeClear = sceneController.GetComponent<P4_JudgeClear>();
        cntBlocks = judgeClear.cntBlocks;

        for (int i = 0; i < 4; i++) {
            isBlocked[i] = new bool[6];
            for (int j = 0; j < 6; j++) {
                isBlocked[i][j] = false;
            }
        }
    }

    private void OnMouseEnter() {
        Debug.Log("그룹에 마우스 올라감");
        isHover = true;
    }

    private void OnMouseExit() {
        isHover = false;
    }

    private void Update() {
        if (isHover == true && judgeClear.isActioning == false) {

            if (transform.localPosition.x < 2 - 0.1) { //Front
                arrows[0].GetComponent<SpriteRenderer>().enabled = true;
                arrows[0].GetComponent<BoxCollider>().enabled = true;
            }
            if (transform.localPosition.z < 2 - 0.1) { //Right
                arrows[1].GetComponent<SpriteRenderer>().enabled = true;
                arrows[1].GetComponent<BoxCollider>().enabled = true;
            }
            if (transform.localPosition.x > 0 + 0.1) { //Back
                arrows[2].GetComponent<SpriteRenderer>().enabled = true;
                arrows[2].GetComponent<BoxCollider>().enabled = true;
            }
            if (transform.localPosition.z > 0 + 0.1) { //Left
                arrows[3].GetComponent<SpriteRenderer>().enabled = true;
                arrows[3].GetComponent<BoxCollider>().enabled = true;
            }

            for (int i = 0; i < 4; i++) { //가장 위 블록도 못 가는 경우
                if (isBlocked[i][cntBlocks - 1]) {
                    arrows[i].GetComponent<SpriteRenderer>().enabled = false;
                    arrows[i].GetComponent<BoxCollider>().enabled = false;
                }
            }
        }

        else if (isHover == false && isArrowHover == false || isArrowOn == true) {

            for (int i = 0; i < 4; i++) {
                arrows[i].GetComponent<SpriteRenderer>().enabled = false;
                arrows[i].GetComponent<BoxCollider>().enabled = false;
            }

            isArrowOn = false;
        }
    }
}
