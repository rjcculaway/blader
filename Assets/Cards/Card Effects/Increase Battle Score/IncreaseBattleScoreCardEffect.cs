using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class IncreaseBattleScoreCardEffect : CardEffect {

    [SerializeField] public IncreaseBattleScoreCardEffectProperties properties;
    private Player source;

    public IncreaseBattleScoreCardEffect(IncreaseBattleScoreCardEffectProperties properties, Player source): base() {
        this.properties = properties;
        this.source = source;
    }

    public override void Execute() {
        source.GainBattleScore(properties.scoreGain);
    }

    public override void Undo() {
        source.LoseBattleScore(properties.scoreGain);
    }
}