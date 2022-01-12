using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talk_test : MonoBehaviour
{
    public TalkBase talk;
    public void TEST1()
    {
        TalkSystem.instance.SetTalk(talk);
        TalkSystem.instance.Play();
    }

    public void TEST2()
    {
        TalkSystem.instance.Next();
    }
}
