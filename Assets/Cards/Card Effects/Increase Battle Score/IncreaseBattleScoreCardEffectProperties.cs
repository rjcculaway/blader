using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseBattleScoreCardEffectProperties", menuName = "Card Effect Properties/Increase Battle Score Properties")]
public class IncreaseBattleScoreCardEffectProperties : ScriptableObject
{
    [SerializeField]
    public int scoreGain;
}
