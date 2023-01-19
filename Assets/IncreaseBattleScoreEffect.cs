using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBattleScoreEffect : CardEffect
{
    [SerializeField]
    private int scoreGain = 1;
    public override void Execute(Player player) {
        base.Execute(player);
        player.GainBattleScore(scoreGain);
        return;
    }

    public override void Undo(Player player) {
        base.Undo(player);
        player.LoseBattleScore(scoreGain);
        return;
    }
}
