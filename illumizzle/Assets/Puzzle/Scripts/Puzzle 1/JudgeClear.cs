using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeClear : MonoBehaviour {

    public int cntFitTrigger = 0;

    void Update() {
        if (cntFitTrigger == 16) {
            Debug.Log("ÆÛÁñ Å¬¸®¾î!!");
        }
    }
}
