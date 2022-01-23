using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_TileScript : MonoBehaviour {

    public GameObject sceneController;
    public GameObject leftButton;
    public GameObject rightButton;

    private void OnMouseDown() {
        P1_ExchangeTile exchangeTile = sceneController.GetComponent<P1_ExchangeTile>();
        P1_RotateLeft rotateLeft = leftButton.GetComponent<P1_RotateLeft>();
        P1_RotateRight rotateRight = rightButton.GetComponent<P1_RotateRight>();

        if (exchangeTile.isMooving == false 
            && rotateLeft.isRotatingLeft == false && rotateRight.isRotatingRight == false
            && gameObject.TryGetComponent(typeof(P1_IsFixedTile), out Component component) == false) {

            if (exchangeTile.calledTile1 == null) {
                exchangeTile.calledTile1 = gameObject;
                Debug.Log("첫 번째 타일 선택됨");
            }
            else {
                exchangeTile.calledTile2 = gameObject;
                Debug.Log("두 번째 타일 선택됨");
            }
        }
    }
}