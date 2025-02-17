using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSystem : MonoBehaviour
{
    public static AreaSystem instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        DontDestroyOnLoad(canvas);
        mask = characterPanel.GetComponent<UnityEngine.UI.Mask>();
    }

    public static Area CurrentArea { private set; get; }
    private static bool isWalking = false; // 이동 중인가

    public static WaitWhile waitWalk = new WaitWhile(() => isWalking);
    private WaitForEndOfFrame frame = new WaitForEndOfFrame();

    private Vector3 position;
    private int faceCount = 0;

    #region [ 오브젝트 ]

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private RectTransform characterPanel;
    private UnityEngine.UI.Mask mask;

    [SerializeField]
    private UnityEngine.UI.Image titleBG;
    [SerializeField]
    private TMPro.TMP_Text title;

    #endregion

    private RectTransform target;

    private void Start()
    {
        int charCount = DataSystem.GetData("Setting", "Faces", 2);
        UpdateCharacters(charCount);
    }

    public void UpdateCharacters(int count = -1)
    {
        if (faceCount >= count) return;

        for (int i = faceCount; i < count; i++)
            canvas.transform.GetChild(i).gameObject.SetActive(true);
    }

    public void SetArea(Area area)
    {
        if (CurrentArea == area) return;
        CurrentArea = area;

        //이름 보여주기?

        IEnumerator coShowTitle()
        {
            float progress, duration = 0.5f;

            Color bef = Color.white, next = bef; bef.a = 0;
            titleBG.color = title.color = bef;
            title.text = area.title;

            for (int i = 0; i < 2; i++)
            {
                progress = 0;
                while (progress < duration)
                {
                    titleBG.color = title.color = Color.Lerp(bef, next, progress / duration);

                    progress += Time.deltaTime;
                    yield return frame;
                }
                titleBG.color = title.color = next;
                Color tmp = bef; bef = next; next = tmp;

                yield return new WaitForSeconds(2f);
            }
        }
        StartCoroutine(coShowTitle());
    }

    public void Walk(int index = -1, bool isAnimate = true)
    {
        if (CurrentArea == null) return;
        if (isWalking) return;

        target = GetTarget(index);
        if (target == null) return;

        isWalking = true;

        IEnumerator CoWalk()
        {
            const float speed = 600f;
            float progress = 0, duration = Vector3.Distance(target.anchoredPosition, characterPanel.anchoredPosition) / speed;

            while(progress < duration && isAnimate)
            {
                float clamp = progress / duration;
                clamp = LineAnimation.Lerp(0, 1, clamp, 1, 0.3f, 0.3f);

                characterPanel.anchoredPosition = Vector3.Lerp(position, target.anchoredPosition, clamp);
                progress += Time.deltaTime;

                yield return frame;
            }
            position = characterPanel.anchoredPosition = target.anchoredPosition;
            SFXSystem.instance.StopSound(0.25f);

            yield return new WaitForSeconds(0.5f);
            isWalking = false;
        }

        StartCoroutine(CoWalk());
    }

    private RectTransform GetTarget(int index = -1)
    {
        Transform target = null;
        try
        {
            if (index == -1)
                target = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform;
            else target = CurrentArea.bgImage.transform.GetChild(index);
        }
        catch { }

        return target.GetComponent<RectTransform>();
    }

    private void Update()
    {
        //if(!isWalking && target != null)
        //{
        //    position = characterPanel.anchoredPosition = target.anchoredPosition;
        //}

        bool flag = true;

        flag = flag && CurrentArea != null;
        flag = flag && CurrentArea.name == UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        mask.enabled = !flag;
    }
}
