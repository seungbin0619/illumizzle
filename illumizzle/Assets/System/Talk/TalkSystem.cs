using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkSystem : MonoBehaviour
{
    #region [ 인스턴스 초기화 ]

    public static TalkSystem instance;
    private Canvas canvas;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(instance);
            instance = this;
        }

        canvas = GetComponent<Canvas>();
    }

    #endregion

    #region [ 대화창 오브젝트 ]

    [SerializeField]
    private Transform characterPanel;

    [SerializeField]
    private Transform scriptBorder;

    [SerializeField]
    private Transform nameBorder;

    [SerializeField]
    private TMPro.TMP_Text scriptText;

    [SerializeField]
    private TMPro.TMP_Text nameText;

    [SerializeField]
    private UnityEngine.UI.Image nextButton;

    [SerializeField]
    private Target characterPrefab;

    #endregion

    #region [ 대화 정보 ]

    public static TalkBase CurrentTalk { get; private set; }
    public static Dictionary<CharacterBase, Target> Characters { get; private set; }

    public static bool IsLoaded { get { return CurrentTalk != null; } }
    private static int talkIndex;

    #endregion

    public void SetTalk(TalkBase talk)
    {
        CurrentTalk = talk;
    }

    public void Play()
    {
        //Close();
        gameObject.SetActive(true);

        talkIndex = 0;
        Characters = new Dictionary<CharacterBase, Target>();

        // 캐릭터 배치
        for (int i = 0; i < CurrentTalk.characters.Length; i++) {
            CharacterBase character = CurrentTalk.characters[i].character;
            int position = (int)CurrentTalk.characters[i].position;

            Target obj = Instantiate(characterPrefab, characterPanel.GetChild(position));
            obj.Initialize(character, position);

            Characters.Add(character, obj);
        }

        Next();
    }

    public void Next()
    {
        if (!IsLoaded) return;
        if(CurrentTalk.Count <= talkIndex)
        {
            // 대화 종료
            Close();

            return;
        }

        TalkBase.Script script = CurrentTalk.GetScript(talkIndex++);
        //Sprite sprite = script.character.sprites[script.sprite];
        //Characters[script.character] // <- 애니메이션 적용할 때 사용

        scriptText.text = script.text;
        nameText.text = script.character.name;

        foreach(Target target in Characters.Values)
            target.ChangeFocus(script.character);
    }

    private void Close()
    {
        gameObject.SetActive(false);
        CurrentTalk = null;

        foreach (Transform group in characterPanel)
            foreach (Transform child in group)
                Destroy(child.gameObject);
    }

    public void Update()
    {
        if (canvas.worldCamera == Camera.current) return;
        canvas.worldCamera = Camera.current;
    }
}
