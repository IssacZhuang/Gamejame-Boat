using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TargetInfo
{
    public bool IsCharacter => targetCharacter != null;

    public Vector3 location;
    public Character targetCharacter;
}
