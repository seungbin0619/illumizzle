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
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Village");
        ActionSystem.instance.Play();
    }

    public void LoadGame()
    {
        DataSystem.Load();

        string currentName = new string[] { 
                "Village", "Forest", "Desert", "Coast", "Workroom" 
            }[DataSystem.GetData("Setting", "CurrentMap", 0)];

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
