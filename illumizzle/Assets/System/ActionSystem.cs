using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    #region [ 인스턴스 초기화 ]

    public static ActionSystem instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        actions = new List<Action>();
    }

    #endregion
    public struct Action
    {
        public enum ActionType
        {
            Talk,  // 대화
            Move,  // 지역(씬) 이동
            Puzzle // 퍼즐로 이동
        }
        public ActionType type;
        public List<object> args;
    }
    private List<Action> actions;
    private static Action currentAction;

    public bool IsCompleted { get { return actions.Count == 0; } }

    private WaitWhile wait = null;
    private static readonly WaitWhile waitTalk = new WaitWhile(() => TalkSystem.IsLoaded); // 대화 켜진 동안 기다리기

    private static AsyncOperation operation;
    private static readonly WaitWhile waitMove = new WaitWhile(() => !operation.isDone);

    private static readonly WaitWhile waitPuzzle = new WaitWhile(() => PuzzleSystem.currentPuzzle != "");

    public void AddAction(Action.ActionType type, params object[] args)
    {
        Action action = new Action();
        action.type = type;
        action.args = new List<object>();
        action.args.AddRange(args);

        actions.Add(action);
    }

    public void Play()
    {
        IEnumerator CoPlay()
        {
            while (!IsCompleted)
            {
                Next();
                yield return wait;

                /*
                switch (currentAction.type)
                {
                    case Action.ActionType.Talk: break;
                    case Action.ActionType.Move:
                        //Debug.Log(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                        TalkSystem.instance.UpdateCamera();

                        break;
                    case Action.ActionType.Puzzle: break;
                }
                */
            }
        }
        StartCoroutine(CoPlay());
    }

    private void Next()
    {
        if (IsCompleted) return;
        currentAction = actions[0];

        switch(currentAction.type)
        {
            case Action.ActionType.Talk:
                TalkBase talk = (TalkBase)currentAction.args[0];

                TalkSystem.instance.SetTalk(talk);
                TalkSystem.instance.Play();

                wait = waitTalk;

                break;
            case Action.ActionType.Move:
                string SceneName = (string)currentAction.args[0];
                operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);

                wait = waitMove;

                break;
            case Action.ActionType.Puzzle:
                string PuzzleName = (string)currentAction.args[0];
                PuzzleSystem.instance.GoPuzzle(PuzzleName);

                wait = waitPuzzle;

                break;
        }

        actions.RemoveAt(0);
    }
}
