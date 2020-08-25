using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog")]
public class Dialogue: ScriptableObject
{
    public bool hasChoice;
    public string choice1;
    public string choice2;
    [TextArea(3,10)]
    public string[] sentences;
}
