using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public new string name;     // 지역 이름
    [SerializeField]
    private Vector3[] positions; // 스테이지 버튼 위치
    private int LevelCount { get { return positions.Length; } }

    [SerializeField]
    private UnityEngine.UI.Image bgImage;
    private RectTransform bgRect;

    private void Awake()
    {
        bgRect = bgImage.rectTransform;
    }

    protected virtual void Start()
    {
        for (int i = 0; i < LevelCount; i++)
        {
            Transform child = bgRect.GetChild(i);
            Vector3 targetPosition = new Vector3(
                bgRect.rect.width * positions[i].x, 
                bgRect.rect.height * positions[i].y);

            child.localPosition = targetPosition * 0.5f;
            child.gameObject.SetActive(true);
        }
    }

    protected void PlayAction()
    {
        ActionSystem.instance.Play();
    }
}
