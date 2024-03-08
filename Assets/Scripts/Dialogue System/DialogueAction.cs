using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.Dialogue
{
    public enum DialogueAction
    {
        None,
        IncreaseSanity,
        DecreaseSanity,
        IncreaseGoodChoiceCount,
        IncreaseNeutralChoiceCount,
        IncreaseBadChoiceCount,
        CulverIncreaseCount,
        JennieIncreaseCount,
        LucyIncreaseCount,
        MaryIncreaseCount
    }
}