using UnityEngine;
using System;

[Serializable]
public class FSMTransition
{
    public FSMDecision decision;
    public string TrueState;
    public string FalseState;
}