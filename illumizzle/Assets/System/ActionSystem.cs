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
            Puzzle, // 퍼즐로 이동
            Fade,
            Walk,
            Sound,
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

    private static readonly WaitWhile waitFade = new WaitWhile(() => FadeSystem.instance.isAnimated);

    private static readonly WaitWhile waitWalk = AreaSystem.waitWalk;

    public static readonly WaitWhile waitComplete = new WaitWhile(() => !instance.IsCompleted);

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
                actions.RemoveAt(0);
                
                switch (currentAction.type)
                {
                    case Action.ActionType.Talk: break;
                    case Action.ActionType.Move:
                        CursorSystem.instance.SetCursor(0);
                        break;
                    case Action.ActionType.Puzzle:
                        CursorSystem.instance.SetCursor(0); break;
                }
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
                CursorSystem.instance.SetCursor(0);

                TalkBase talk = (TalkBase)currentAction.args[0];

                TalkSystem.instance.SetTalk(talk);
                TalkSystem.instance.Play();

                wait = waitTalk;

                break;
            case Action.ActionType.Move:
                CursorSystem.instance.SetCursor(0);

                string SceneName = (string)currentAction.args[0];
                operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);

                wait = waitMove;

                break;
            case Action.ActionType.Puzzle:
                CursorSystem.instance.SetCursor(0);

                string PuzzleName = (string)currentAction.args[0];
                PuzzleSystem.instance.GoPuzzle(PuzzleName);

                wait = waitPuzzle;

                break;
            case Action.ActionType.Fade:
                CursorSystem.instance.SetCursor(0);

                float target = float.Parse(currentAction.args[0].ToString());
                float duration = float.Parse(currentAction.args[1].ToString());

                //Debug.Log(target);
                //Debug.Log(duration);
                
                FadeSystem.instance.StartFade(target, duration);

                wait = waitFade;

                break;
            case Action.ActionType.Walk:
                int index = int.Parse(currentAction.args[0].ToString());

                AreaSystem.instance.Walk(index);
                DataSystem.SetData("LastPosition", AreaSystem.CurrentArea.name, index);

                wait = waitWalk;

                break;
            case Action.ActionType.Sound:
                int sound = int.Parse(currentAction.args[0].ToString());

                if (sound == -1) SFXSystem.instance.StopSound();
                else SFXSystem.instance.PlaySound(sound);
                
                wait = null;

                break;
        }
    }
}
