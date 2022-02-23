using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField]
    private int mapIndex = -1;

    public new string name;     // 지역 이름
    public string title;

    public UnityEngine.UI.Image bgImage;

    [SerializeField]
    protected Sprite[] images = new Sprite[2];

    protected RectTransform bgRect;

    [SerializeField]
    protected TalkBase[] talks;

    [SerializeField]
    protected bool isPuzzle = false;

    [SerializeField]
    protected bool face = false;

    private void Awake()
    {
        bgRect = bgImage.rectTransform;
    }

    protected virtual void Start()
    {
        /*
        float w = bgRect.rect.width * 0.5f, h = bgRect.rect.height* 0.5f;
        for (int i = 0; i < LevelCount; i++)
        {
            Transform child = bgRect.GetChild(i);
            Debug.Log((child.localPosition.x / w) + " , " + (child.localPosition.y / h));
        }
        */

        /*
        for (int i = 0; i < LevelCount; i++)
        {
            Transform child = bgRect.GetChild(i);
            Vector3 targetPosition = new Vector3(
                bgRect.rect.width * positions[i].x,
                bgRect.rect.height * positions[i].y);

            child.localPosition = targetPosition * 0.5f;
            if (!isPuzzle) child.gameObject.SetActive(true);
        }
        */

        if (face)
        {
            AreaSystem.instance.SetArea(this);

            int lastPosition = DataSystem.GetData("LastPosition", name, 0);
            AreaSystem.instance.Walk(lastPosition, false);
        }

        IEnumerator LateStart()
        {
            yield return ActionSystem.waitComplete;

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 0, 0.5f);
            this.LateStart();
        }

        StartCoroutine(LateStart());

        if (mapIndex >= 0 && mapIndex < 6)
        {
            DataSystem.SetData("Setting", "CurrentMap", mapIndex);
            DataSystem.SaveData();
        }
    }

    protected virtual void LateStart() { }

    protected void PlayAction()
    {
        ActionSystem.instance.Play();
    }

    public virtual void GoScene(string name)
    {
        if (ActionSystem.instance.isPlaying) return;

        if (name == "Map") ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Sound, 4);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 0.5f);
        ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, name);

        ActionSystem.instance.Play();
    }

    public void OpenSetting()
    {
        SettingSystem.instance.OpenSetting();
    }
}
