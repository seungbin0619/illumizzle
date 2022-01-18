using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeClear : MonoBehaviour {
    /*
    public int cntTotFitTrigger;
    public int cntFitTrigger = 0;

    void Update() {
        if (cntFitTrigger == cntTotFitTrigger) {
            Debug.Log("���� Ŭ����!!");
        }
    }
    */

    public int cntTotFitTrigger;

    private int _cntFitTrigger = 0;
    public int cntFitTrigger
    {
        get
        {
            return _cntFitTrigger;
        }set
        {
            _cntFitTrigger = value;
            if(_cntFitTrigger == cntTotFitTrigger)
            {
                Debug.Log("���� Ŭ����");

                PuzzleSystem.instance.AfterPuzzle(true);
            }
        }
    }
}
