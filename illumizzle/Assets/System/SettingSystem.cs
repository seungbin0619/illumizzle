using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSystem : MonoBehaviour
{
    #region [ �ν��Ͻ� �ʱ�ȭ ]

    public static SettingSystem instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(canvas.gameObject);
    }

    #endregion

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private UnityEngine.UI.Slider[] slider;

    private bool isOpen = false;
    
    public void OpenSetting()
    {
        if (!DataSystem.HasData("Setting", "Bgm")) DataSystem.SetData("Setting", "Bgm", 50);
        else slider[0].value = DataSystem.GetData("Setting", "Bgm", 50) * 0.01f;

        if (!DataSystem.HasData("Setting", "Sound")) DataSystem.SetData("Setting", "Sound", 50);
        else slider[1].value = DataSystem.GetData("Setting", "Sound", 50) * 0.01f;

        Setting(true);
    }

    public void CloseSetting()
    {
        Setting(false);
        DataSystem.SaveData();
    }

    private void Setting(bool flag)
    {
        canvas.gameObject.SetActive(flag);
        isOpen = flag;
    }
    
    public void ToTitle()
    {
        ActionSystem.instance.actions.Clear();

        CloseSetting();

        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 0.5f);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Title");

        ActionSystem.instance.Play();
    }

    public void OnBGMChanged()
    {
        DataSystem.SetData("Setting", "Bgm", (int)(slider[0].value * 100));
    }

    public void OnSoundChanged()
    {
        DataSystem.SetData("Setting", "Sound", (int)(slider[1].value * 100));
    }

    private void Update()
    {
        if (!ActionSystem.instance.IsCompleted && ActionSystem.instance.actions[0].type != ActionSystem.Action.ActionType.Puzzle) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Setting(!isOpen);
        }
    }
}
