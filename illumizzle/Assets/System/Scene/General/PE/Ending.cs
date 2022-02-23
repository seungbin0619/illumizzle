using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField]
    private Sprite[] image = new Sprite[2];
    private bool flag = false;
    private RectTransform rect;

    private void Start()
    {
        SFXSystem.instance.BgmChange(0);

        UnityEngine.UI.Image img = GetComponent<UnityEngine.UI.Image>();
        rect = img.rectTransform;

        IEnumerator LateStart()
        {
            yield return ActionSystem.waitComplete;
            flag = true;
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 0, 1.5f);
            ActionSystem.instance.Play();

            yield return new WaitForSeconds(0.5f);
            flag = true;

            img.sprite = image[1];
            yield return new WaitForSeconds(1f);

            img.sprite = image[0];
            yield return new WaitForSeconds(0.05f);

            img.sprite = image[1];
            yield return new WaitForSeconds(0.05f);

            img.sprite = image[0];
            yield return new WaitForSeconds(1f);

            img.sprite = image[1];
            yield return new WaitForSeconds(0.05f);

            img.sprite = image[0];

            yield return new WaitForSeconds(1.5f);


            DataSystem.SetData("Story", "LIGHT", 1);

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 1.5f);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Workroom");
            ActionSystem.instance.Play();
        }

        StartCoroutine(LateStart());
    }

    public void Update()
    {
        if (!flag) return;

        rect.offsetMin = Vector2.Lerp(rect.offsetMin, Vector2.zero, Time.deltaTime * 0.5f);
        rect.offsetMax = Vector2.Lerp(rect.offsetMax, Vector2.zero, Time.deltaTime * 0.5f);
    }
}
