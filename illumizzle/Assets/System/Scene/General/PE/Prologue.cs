using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    [SerializeField]
    private Sprite[] image = new Sprite[2];

    private void Start()
    {
        UnityEngine.UI.Image img = GetComponent<UnityEngine.UI.Image>();

        IEnumerator LateStart()
        {
            yield return ActionSystem.waitComplete;

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 0, 1.5f);
            ActionSystem.instance.Play();

            yield return ActionSystem.waitComplete;

            img.sprite = image[0];
            yield return new WaitForSeconds(1f);

            img.sprite = image[1];
            yield return new WaitForSeconds(0.05f);

            img.sprite = image[0];
            yield return new WaitForSeconds(1f);

            img.sprite = image[1];
            yield return new WaitForSeconds(0.05f);

            img.sprite = image[0];
            yield return new WaitForSeconds(0.1f);

            img.sprite = image[1];

            yield return new WaitForSeconds(1.5f);

            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Fade, 1, 1.5f);
            ActionSystem.instance.AddAction(ActionSystem.Action.ActionType.Move, "Village");
            ActionSystem.instance.Play();
        }

        StartCoroutine(LateStart());
    }
}
