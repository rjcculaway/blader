using System;
using UnityEngine;
using UnityEngine.Assertions;

[Serializable]
public class IncreaseBattleScoreCardEffect : CardEffect {

    [SerializeField] public IncreaseBattleScoreCardEffectProperties properties;

    public IncreaseBattleScoreCardEffect(IncreaseBattleScoreCardEffectProperties properties, Player source): base() {
        this.properties = properties;
        this.source = source;
    }

    public override void Execute() {
        Assert.IsNotNull(source);
        source.GainBattleScore(properties.scoreGain);
    }

    public override void Undo() {
        Assert.IsNotNull(source);
        source.LoseBattleScore(properties.scoreGain);
    }
}