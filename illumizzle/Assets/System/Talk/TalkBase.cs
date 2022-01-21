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
        public CharacterBase character;  // ĳ����
        public int sprite;               // �̹��� ��ȣ

        public string text;              // ��ȭ ����
        public List<CharacterBase> hide; // ĳ���� ������
        public string command;           // ��Ÿ ȣ��
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

        public CharacterBase character; // ĳ����
        public POSITION position;
    }

    [SerializeField]
    private Script[] scripts;          // ��ȭ ���
    public Character[] characters;    // ��ȭ ���� ĳ����

    public int Count { get { return scripts.Length; } }

    public Script GetScript(int index)
    {
        return scripts[index];
    }
}
