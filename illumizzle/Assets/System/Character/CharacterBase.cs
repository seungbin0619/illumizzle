using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Name", menuName = "Character")]
public class CharacterBase : ScriptableObject
{
    public new string name;  // ĳ���� �̸�
    public Sprite[] sprites; // ĳ���� �̹�����
    public Sprite face;
}
