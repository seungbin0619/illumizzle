using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeTile : MonoBehaviour {

    public GameObject calledTile1 = null;
    public GameObject calledTile2 = null;
    public bool isMooving = false;
    private Vector3 position1, position2;

    void Update() {
        if (calledTile1 != null && calledTile2 != null && isMooving == false) {
            if (calledTile1 != calledTile2 && calledTile1.CompareTag(calledTile2.tag)) {
                position1 = calledTile1.transform.position;
                position2 = calledTile2.transform.position;
                isMooving = true;
                Debug.Log("타일 교환 시작");

                if (calledTile1.CompareTag("yf")) calledTile1.transform.position += Vector3.up / 100;
                else calledTile1.transform.position += Vector3.right / 100 + Vector3.forward / 100;

            }
            else {
                calledTile1 = null;
                calledTile2 = null;
                Debug.Log("타일 교환 불가");
            }
        }
    }

    private void FixedUpdate() {
        if (isMooving == true) {
            calledTile1.transform.position += (position2 - position1) / 12.0f;
            calledTile2.transform.position += (position1 - position2) / 12.0f;

            if (Vector3.Distance(calledTile1.transform.position,
                                 position2) <= 0.1f) {
                calledTile1.transform.position = position2;
                calledTile2.transform.position = position1;

                calledTile1 = null;
                calledTile2 = null;
                isMooving = false;

                Debug.Log("타일 교환 종료");
            }
        }
    }
}
