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
        SFXSystem.instance.BgmChange(1);

        IEnumerator LateStart()
        {
            yield return ActionSystem.waitComplete;

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 0, 1f);
            ActionSystem.instance.Play();
        }

        StartCoroutine(LateStart());
    }

    [SerializeField]
    private Canvas notice;

    public void StartGame(bool ignore = false)
    {
        DataSystem.Load();
        if(DataSystem.HasData("Story", "Start") && !ignore)
        {
            notice.gameObject.SetActive(true);

            return;
        }

        DataSystem.Load(true);

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 1f);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Prologue");
        ActionSystem.instance.Play();

        SFXSystem.instance.PlaySound(1); // 시작
        SFXSystem.instance.BgmChange(0);
    }

    public void HideNotice()
    {
        notice.gameObject.SetActive(false);
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

        SFXSystem.instance.PlaySound(1); // 시작
        SFXSystem.instance.BgmChange(0);
    }

    public void ExitGame()
    {
        SFXSystem.instance.BgmChange(0);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
