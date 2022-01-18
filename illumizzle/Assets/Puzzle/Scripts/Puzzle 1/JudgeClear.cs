using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeClear : MonoBehaviour {

    public int cntTotFitTrigger;
    public int cntFitTrigger = 0;
    private bool isFinished = false;

    void Update() {
        if (isFinished == false && cntFitTrigger == cntTotFitTrigger) {
            isFinished = true;
            Debug.Log("ÆÛÁñ Å¬¸®¾î!!");
            PuzzleSystem.instance.AfterPuzzle(true);
        }
    }


    //public int cntTotFitTrigger;

    //private int _cntFitTrigger = 0;
    //public int cntFitTrigger
    //{
    //    get
    //    {
    //        return _cntFitTrigger;
    //    }set
    //    {
    //        _cntFitTrigger = value;
    //        if(_cntFitTrigger == cntTotFitTrigger)
    //        {
    //            Debug.Log("ÆÛÁñ Å¬¸®¾î");

    //            PuzzleSystem.instance.AfterPuzzle(true);
    //        }
    //    }
    //}
}
