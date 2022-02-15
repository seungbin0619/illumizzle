using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystem : MonoBehaviour
{
    #region [ �ν��Ͻ� �ʱ�ȭ ]

    public static MainSystem instance;
    [SerializeField]
    private GameObject talkUI;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);

        DontDestroyOnLoad(this);
        DontDestroyOnLoad(talkUI);

        talkUI.gameObject.SetActive(false);
    }

    #endregion

    public GameEvent OnCameraChanged;
}
