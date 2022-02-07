using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSystem : MonoBehaviour
{
    #region [ �ν��Ͻ� �ʱ�ȭ ]

    public static FadeSystem instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        DontDestroyOnLoad(canvas.gameObject);
    }

    #endregion

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private UnityEngine.UI.Image fade;

    public bool isAnimated = false;

    private readonly WaitForEndOfFrame delay = new WaitForEndOfFrame();

    public void StartFade(float target, float duration = 0.5f)
    {
        //Debug.Log(target + " - " + duration);
        isAnimated = true;
        fade.raycastTarget = true;

        float progress = 0;
        Color color = fade.color, targetColor = color;
        targetColor.a = target;

        IEnumerator CoStartFade()
        {
            while (true)
            {
                float clamp = Mathf.Clamp(progress / duration, 0, 1);
                fade.color = Color.Lerp(color, targetColor, LineAnimation.Lerp(0, 1, clamp, 1, 0, 1));

                yield return delay;
                progress += Time.deltaTime;

                if (progress > duration) break;
            }

            fade.color = targetColor;
            fade.raycastTarget = false;

            isAnimated = false;
        }

        StartCoroutine(CoStartFade());
    }
}
