using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSystem : MonoBehaviour
{
    #region [ 인스턴스 초기화 ]

    public static CursorSystem instance;
    [SerializeField]
    private RectTransform CursorCanvas;
    [SerializeField]
    private RectTransform rect;
    [SerializeField]
    private UnityEngine.UI.RawImage cursor;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(CursorCanvas.gameObject);
    }

    #endregion

    [System.Serializable]
    public struct CursorData
    {
        public Texture2D texture;
        public Vector2 spot;
    }

    [SerializeField]
    private List<CursorData> cursors;
    private int index;

    public void Start()
    {
        index = 0;
        cursor.texture = cursors[index].texture;

        Cursor.visible = false;
    }

    public void SetCursor(int index = 0)
    {
        if (this.index == index) return;

        this.index = index;
        cursor.texture = cursors[index].texture;
    }

    private void Update()
    {
        Vector3 position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        cursor.rectTransform.anchoredPosition = position * CursorCanvas.sizeDelta + cursors[index].spot;
    }
}
