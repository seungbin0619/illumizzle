using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Talk Name", menuName = "Talk")]
public class TalkBase : ScriptableObject
{
    [Serializable]
    public struct Script
    {
        public CharacterBase character;  // 캐릭터
        public int sprite;               // 이미지 번호

        public string text;              // 대화 내용
        public List<CharacterBase> hide; // 캐릭터 가리기
        public string command;           // 기타 호출
    }

    [Serializable]
    public struct Character
    {
        public enum POSITION
        {
            Left = 0,
            Right
            //Custom
        }

        public CharacterBase character; // 캐릭터
        public POSITION position;
    }

    [SerializeField]
    private Script[] scripts;          // 대화 목록
    public Character[] characters;    // 대화 등장 캐릭터

    public int Count { get { return scripts.Length; } }

    public Script GetScript(int index)
    {
        return scripts[index];
    }
}
