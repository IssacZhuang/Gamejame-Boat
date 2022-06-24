using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TargetInfo
{
    public bool IsCharacter => targetCharacter != null;

    public Vector2 location;
    public Character targetCharacter;
}
