using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_JudgeClear : MonoBehaviour {

    P2_ActionController actionController;

    public GameObject[] meeples = new GameObject[2];
    public GameObject[] destinations = new GameObject[2];

    private bool isFinished = false;

    public GameObject clearText; //

    private void Start() {
        actionController = gameObject.GetComponent<P2_ActionController>();
    }

    void Update() {

        bool isArrived = true;

        for (int i = 0; i < actionController.meepleCnt && isArrived; i++) {
            float dist = Vector3.Distance(meeples[i].transform.position, destinations[i].transform.position);
            if (dist > 0.05f) isArrived = false;
        }

        //if (isFinished == false && isArrived == true) {
        if (isFinished == false && isArrived == true || Input.GetKeyDown(KeyCode.S)) {
            isFinished = true;
            Debug.Log("ÆÛÁñ Å¬¸®¾î!!");
            clearText.SetActive(true);
            //PuzzleSystem.instance.AfterPuzzle(true);
        }
    }
}
