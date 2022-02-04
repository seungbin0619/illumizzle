using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSystem : MonoBehaviour
{
    #region [ �ν��Ͻ� �ʱ�ȭ ]

    public static FadeSystem instance;

    [SerializeField]
    private Canvas canvas;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(instance);
            instance = this;
        }
    }

    #endregion

    [SerializeField]
    private UnityEngine.UI.Image hide;
}
