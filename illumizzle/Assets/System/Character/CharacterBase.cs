using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Name", menuName = "Character")]
public class CharacterBase : ScriptableObject
{
    public new string name;  // 캐릭터 이름
    public Sprite[] sprites; // 캐릭터 이미지들
    public Sprite face;
}
