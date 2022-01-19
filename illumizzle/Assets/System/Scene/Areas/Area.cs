using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public new string name;     // 지역 이름
    [SerializeField]
    protected Vector3[] positions; // 스테이지 버튼 위치
    protected int LevelCount { get { return positions.Length; } }

    [SerializeField]
    protected UnityEngine.UI.Image bgImage;
    protected RectTransform bgRect;

    [SerializeField]
    protected TalkBase[] talks;

    [SerializeField]
    protected bool isPuzzle = false;

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

        for (int i = 0; i < LevelCount; i++)
        {
            Transform child = bgRect.GetChild(i);
            Vector3 targetPosition = new Vector3(
                bgRect.rect.width * positions[i].x, 
                bgRect.rect.height * positions[i].y);

            child.localPosition = targetPosition * 0.5f;
            if(!isPuzzle) child.gameObject.SetActive(true);
        }
    }

    protected void PlayAction()
    {
        ActionSystem.instance.Play();
    }
}
