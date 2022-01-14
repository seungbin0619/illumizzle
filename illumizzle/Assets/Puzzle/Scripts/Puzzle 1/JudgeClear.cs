using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeClear : MonoBehaviour {

    public int cntTotFitTrigger;
    public int cntFitTrigger = 0;

    void Update() {
        if (cntFitTrigger == cntTotFitTrigger) {
            Debug.Log("ÆÛÁñ Å¬¸®¾î!!");
        }
    }
}
