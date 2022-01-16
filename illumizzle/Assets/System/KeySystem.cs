using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySystem : MonoBehaviour
{
    #region [ 인스턴스 초기화 ]

    public static KeySystem instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    #endregion

    public GameEvent waitKeyInput;

    private static bool KeySpace { get { return Input.GetKeyDown(KeyCode.Space); } }
    private static bool KeyLButton { get { return Input.GetMouseButtonDown(0); } }

    public static readonly WaitUntil waitNext = new WaitUntil(() => KeySpace || KeyLButton);

    private void Update()
    {
        if(KeySpace || KeyLButton)
            waitKeyInput.Raise();
    }
}
