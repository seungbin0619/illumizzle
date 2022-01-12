using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private void Awake()
    {
        // 불러오기 작업?
    }

    public void StartGame()
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Village");
        ActionSystem.instance.Play();
    }

    public void ExitGame()
    {

    }
}
