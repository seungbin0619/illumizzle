using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public CharacterBase target;

    private UnityEngine.UI.Image size;
    [SerializeField]
    private UnityEngine.UI.Image image;

    private void Awake()
    {
        size = GetComponent<UnityEngine.UI.Image>();
    }

    public void Initialize(CharacterBase target, int position)
    {
        this.target = target;

        transform.rotation = new Quaternion(0, position * 180f, 0, 0);
        image.sprite = size.sprite = target.sprites[0];

        size.SetNativeSize();
        image.SetNativeSize();
    }

    public void ChangeFocus(CharacterBase character)
    {
        image.color = target == character ? Color.white : Color.gray;
    }
}
