using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private void Awake()
    {
        // 불러오기 작업?
    }

    private void Start()
    {
        IEnumerator LateStart()
        {
            yield return ActionSystem.waitComplete;

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 0, 1f);
            ActionSystem.instance.Play();
        }

        StartCoroutine(LateStart());
    }

    public void StartGame()
    {
        DataSystem.Load(true);

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 1f);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Prologue");
        ActionSystem.instance.Play();
    }

    public void LoadGame()
    {
        DataSystem.Load();

        int index = DataSystem.GetData("Setting", "CurrentMap");
        if (index == -1)
        {
            StartGame();

            return;
        }

        string currentName = new string[] { 
                "Village", "Forest", "Desert", "Coast", "Rock", "Workroom" 
            }[index];

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 1f);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, currentName);
        ActionSystem.instance.Play();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
