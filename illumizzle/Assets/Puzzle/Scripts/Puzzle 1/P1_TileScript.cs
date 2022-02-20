using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_TileScript : MonoBehaviour {

    public GameObject sceneController;
    public GameObject leftButton;
    public GameObject rightButton;
    private GameObject cubeBase;

    public AudioSource audioTile;

    private void Start() {
        cubeBase = gameObject.transform.parent.gameObject;
        //audioTile.Stop();
    }

    private void OnMouseDown() {
        P1_ExchangeTile exchangeTile = sceneController.GetComponent<P1_ExchangeTile>();
        P1_RotateLeft rotateLeft = leftButton.GetComponent<P1_RotateLeft>();
        P1_RotateRight rotateRight = rightButton.GetComponent<P1_RotateRight>();

        if (exchangeTile.isMooving == false 
            && rotateLeft.isRotatingLeft == false && rotateRight.isRotatingRight == false
            && gameObject.TryGetComponent(typeof(P1_IsFixedTile), out Component component) == false) {

            if (exchangeTile.calledTile1 == null) {
                exchangeTile.calledTile1 = gameObject;
                //Debug.Log("첫 번째 타일 선택됨");

                gameObject.transform.GetChild(4).gameObject.SetActive(true);
                int childCnt = cubeBase.transform.childCount;
                for (int i = 0; i < childCnt; i++) {
                    GameObject crObject = cubeBase.transform.GetChild(i).gameObject;
                    if (crObject.name[1] != 'i') break;
                    if (crObject.name[5] != gameObject.name[5] ||
                        crObject.name[6] != gameObject.name[6] ||
                        crObject.name[7] != gameObject.name[7] ) {
                        crObject.transform.GetChild(4).gameObject.SetActive(true);
                    }
                }

                //audioTile.Play();

            }
            else {
                exchangeTile.calledTile2 = gameObject;
                //Debug.Log("두 번째 타일 선택됨");

                int childCnt = cubeBase.transform.childCount;
                for (int i = 0; i < childCnt; i++) {
                    GameObject crObject = cubeBase.transform.GetChild(i).gameObject;
                    if (crObject.name[1] != 'i') break;
                    crObject.transform.GetChild(4).gameObject.SetActive(false);
                }
            }
        }
    }
}