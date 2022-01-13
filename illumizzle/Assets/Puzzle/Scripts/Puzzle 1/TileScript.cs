using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    public GameObject sceneController;
    public GameObject leftButton;
    public GameObject rightButton;

    private void OnMouseDown() {
        ExchangeTile exchangeTile = sceneController.GetComponent<ExchangeTile>();
        RotateLeft rotateLeft = leftButton.GetComponent<RotateLeft>();
        RotateRight rotateRight = rightButton.GetComponent<RotateRight>();

        if (exchangeTile.isMooving == false 
            && rotateLeft.isRotatingLeft == false && rotateRight.isRotatingRight == false) {

            if (exchangeTile.calledTile1 == null) {
                exchangeTile.calledTile1 = gameObject;
                Debug.Log("ù ��° Ÿ�� ���õ�");
            }
            else {
                exchangeTile.calledTile2 = gameObject;
                Debug.Log("�� ��° Ÿ�� ���õ�");
            }
        }
    }
}