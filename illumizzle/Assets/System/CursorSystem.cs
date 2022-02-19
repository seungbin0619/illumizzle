using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSystem : MonoBehaviour
{
    #region [ 인스턴스 초기화 ]

    public static CursorSystem instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
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
        StartCoroutine(CoCursor());
    }

    public void SetCursor(int index = 0)
    {
        if (this.index == index) return;

        this.index = index;
        StartCoroutine(CoCursor());
    }

    IEnumerator CoCursor()
    {
        //while (true)
        //{
            yield return new WaitForEndOfFrame();

            CursorData current = cursors[index];
            Cursor.SetCursor(current.texture, current.spot, CursorMode.ForceSoftware);
        //}
    }
}
