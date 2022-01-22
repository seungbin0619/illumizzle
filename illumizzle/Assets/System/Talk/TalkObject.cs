using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkObject : MonoBehaviour
{
    protected virtual void Start()
    {

    }

    protected virtual void Dispose()
    {
        Destroy(gameObject);
    }
}
