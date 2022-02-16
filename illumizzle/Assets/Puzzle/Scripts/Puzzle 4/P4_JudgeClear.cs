using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_JudgeClear : MonoBehaviour {

    public int cntBlocks;
    public bool isActioning = false;
    public int sizeX, sizeZ;

    public int cntFitBlock = 0;
    public GameObject clearText; //

    private bool isFinished = false;

    void Update() {

        if (cntBlocks == cntFitBlock && isFinished == false || Input.GetKeyDown(KeyCode.S)) {
            isFinished = true;
            Debug.Log("ÆÛÁñ Å¬¸®¾î!!");
            clearText.SetActive(true); //
            //PuzzleSystem.instance.AfterPuzzle(true);
        }
    }
}
