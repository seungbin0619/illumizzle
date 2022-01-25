using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_JudgeClear : MonoBehaviour {
    public GameObject meeple;
    public GameObject destination;

    private bool isFinished = false;

    void Update() {
        float dist = Vector3.Distance(meeple.transform.position, destination.transform.position);
        //if (isFinished == false && dist <= 0.03f) {
        if (isFinished == false && dist <= 0.04f || Input.GetKeyDown(KeyCode.S)) {
            isFinished = true;
            Debug.Log("ÆÛÁñ Å¬¸®¾î!!");
            PuzzleSystem.instance.AfterPuzzle(true);
        }
    }
}
