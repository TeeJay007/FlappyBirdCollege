using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SomeScriptableObject", order = 1)]
public class SomeScriptableObject : ScriptableObject
{
    public float PipeSpeed = 2;
    public float PipeOffset = 5;
}
