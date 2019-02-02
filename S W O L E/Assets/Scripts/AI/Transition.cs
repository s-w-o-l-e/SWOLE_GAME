using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition
{
    // The decision were checking
    public Decision decision;

    // Decision true state
    public State trueState;

    // Decision false state
    public State falseState;
}