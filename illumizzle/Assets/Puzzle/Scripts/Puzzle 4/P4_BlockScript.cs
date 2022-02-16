using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_BlockScript : MonoBehaviour {

    public int[] isBlocked = new int[4];

    private void Start() {
        for (int i = 0; i < 4; i++) {
            isBlocked[i] = 0;
        }
    }

}
