using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_ClickAreaScript : MonoBehaviour {

    public GameObject sceneController;

    GameObject[] arrows = new GameObject[8];

    private bool isHover = false;
    public bool isArrowHover = false;

    P2_ActionController actionController;

    private void Start() {
        for (int i = 0; i < 8; i++) {
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
        if (isHover == true && arrows[0].GetComponent<SpriteRenderer>().enabled == false
            && actionController.isActioning == false) {

            for (int i = 0; i < 8; i++) {
                arrows[i].GetComponent<SpriteRenderer>().enabled = true;
                arrows[i].GetComponent<BoxCollider>().enabled = true;
            }
        }

        else if (isHover == false && isArrowHover == false 
            && arrows[0].GetComponent<SpriteRenderer>().enabled == true) {

            for (int i = 0; i < 8; i++) {
                arrows[i].GetComponent<SpriteRenderer>().enabled = false;
                arrows[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
