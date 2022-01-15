using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    public void GotoBack(string sceneName)
    {
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, sceneName);
        ActionSystem.instance.Play();
    }
}
