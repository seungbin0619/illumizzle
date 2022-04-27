using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_ExchangeTile : MonoBehaviour {

    public GameObject calledTile1 = null;
    public GameObject calledTile2 = null;
    public bool isMooving = false;
    private Vector3 position1, position2;
    private float dist;

    public GameObject sceneController;
    private P1_JudgeClear judgeClear;

    //================Rule Displayer================
    public GameObject rule;
    public int isRuleOn = 0;
    //==============================================

    private void Start() {
        judgeClear = gameObject.GetComponent<P1_JudgeClear>();
    }

    void Update() {
        if (calledTile1 != null && calledTile2 != null && isMooving == false) {
            if (calledTile1 != calledTile2 && calledTile1.CompareTag(calledTile2.tag)) {
                position1 = calledTile1.transform.position;
                position2 = calledTile2.transform.position;
                isMooving = true;
                //Debug.Log("타일 교환 시작");

                judgeClear.handingCnt++;

                if (calledTile1.tag[0] == 'y') {
                    calledTile1.transform.position += Vector3.up / 50;
                    calledTile2.transform.position += Vector3.up / 100;

                    calledTile1.transform.position += Vector3.right / 200 + Vector3.forward / 200;
                    calledTile2.transform.position += Vector3.right / 400 + Vector3.forward / 400;
                }
                else {
                    calledTile1.transform.position += Vector3.right / 50 + Vector3.forward / 50;
                    calledTile2.transform.position += Vector3.right / 100 + Vector3.forward / 100;

                    calledTile1.transform.position += Vector3.up / 200;
                    calledTile2.transform.position += Vector3.up / 400;
                }

                dist = Vector3.Distance(position1, position2);

                SFXSystem.instance.PlaySound(12);

            }
            else {
                calledTile1 = null;
                calledTile2 = null;

                SFXSystem.instance.PlaySound(11);

            }
        }

        //================Rule Displayer================
        if (Input.GetMouseButtonUp(0) && isRuleOn == 2) {
            ConcealRule();
        }
        if (isRuleOn == 1) isRuleOn = 2;
        //==============================================
    }

    private void FixedUpdate() {
        if (isMooving == true && isRuleOn == 0) {
            calledTile1.transform.position += (position2 - position1) / (8 + dist * 3) * 40 * Time.deltaTime;
            calledTile2.transform.position += (position1 - position2) / (8 + dist * 3) * 40 * Time.deltaTime;

            if (Vector3.Distance(calledTile1.transform.position,
                                 position2) <= Time.deltaTime * (8 + dist * 3) * 0.4f) {
                calledTile1.transform.position = position2;
                calledTile2.transform.position = position1;

                calledTile1 = null;
                calledTile2 = null;
                isMooving = false;

                //Debug.Log("타일 교환 종료");
            }
        }
    }

    //================Rule Displayer================
    public void DisplayRule() {
        if (isRuleOn == 0) {
            rule.SetActive(true);
            isRuleOn = 1;
            isMooving = true;
            SFXSystem.instance.PlaySound(8);
        }
    }

    public void ConcealRule() {
        rule.SetActive(false);
        isRuleOn = 0;
        isMooving = false;
        SFXSystem.instance.PlaySound(9);
    }

    //==============================================

}
