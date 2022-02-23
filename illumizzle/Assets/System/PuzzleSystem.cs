using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleSystem : MonoBehaviour
{
    #region [ �ν��Ͻ� �ʱ�ȭ ]

    public static PuzzleSystem instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    #endregion

    private string beforeScene;
    public static string currentPuzzle;
    public static bool isCleared;

    [SerializeField]
    private TalkBase failed;

    public void GoPuzzle(string name)
    {
        SFXSystem.instance.BgmChange(0);

        beforeScene = SceneManager.GetActiveScene().name;
        isCleared = false;
        currentPuzzle = name;

        IEnumerator CoGoPuzzle()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(currentPuzzle);
            yield return new WaitUntil(() => operation.isDone);

            // ������ �ε�ǰ� �� ��?
            yield return new WaitForEndOfFrame();

            FadeSystem.instance.StartFade(0);
            CursorSystem.instance.SetCursor(0);
        }

        StartCoroutine(CoGoPuzzle());
    }

    /// <summary>
    /// ������ Ŭ�����ϰų� �߰��� ����ϰ� ������ ȣ�����ּ���
    /// </summary>
    /// <param name="isCleared">Ŭ���� ����</param>
    public void AfterPuzzle(bool isCleared = false)
    {
        if(isCleared)
            DataSystem.SetData("Puzzle", currentPuzzle, 1);

        currentPuzzle = "";

        IEnumerator CoAfterPuzzle()
        {
            FadeSystem.instance.StartFade(1);
            yield return new WaitWhile(() => FadeSystem.instance.isAnimated);

            AsyncOperation operation = SceneManager.LoadSceneAsync(beforeScene);
            yield return new WaitUntil(() => operation.isDone);
            yield return new WaitForEndOfFrame();

            // ���ư� ����?
            if(!isCleared)
            {
                ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Talk, failed);
            }
        }

        StartCoroutine(CoAfterPuzzle());
    }
}