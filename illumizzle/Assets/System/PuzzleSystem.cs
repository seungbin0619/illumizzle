using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleSystem : MonoBehaviour
{
    #region [ 인스턴스 초기화 ]

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

    public void GoPuzzle(string name)
    {
        beforeScene = SceneManager.GetActiveScene().name;
        isCleared = false;
        currentPuzzle = name;

        IEnumerator CoGoPuzzle()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(currentPuzzle);
            yield return new WaitUntil(() => operation.isDone);

            // 퍼즐이 로드되고 할 일?
            yield return new WaitForEndOfFrame();

            FadeSystem.instance.StartFade(0);
        }

        StartCoroutine(CoGoPuzzle());
    }

    /// <summary>
    /// 퍼즐을 클리어하거나 중간에 취소하고 나가면 호출해주세요
    /// </summary>
    /// <param name="isCleared">클리어 여부</param>
    public void AfterPuzzle(bool isCleared = false)
    {
        if(isCleared)
            DataSystem.SetData("Puzzle", currentPuzzle, 1);

        currentPuzzle = "";

        IEnumerator CoAfterPuzzle()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(beforeScene);
            yield return new WaitUntil(() => operation.isDone);

            // 돌아간 이후?

        }

        StartCoroutine(CoAfterPuzzle());
    }
}