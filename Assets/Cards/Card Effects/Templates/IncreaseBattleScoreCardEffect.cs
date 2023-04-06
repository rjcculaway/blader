using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIncreaseBattleScoreCardEffect", menuName = "Card Effects/Increase Battle Score")]
public class IncreaseBattleScoreCardEffect : CardEffect
{
    [SerializeField]
    private int scoreGain;
    public override void Execute(Player player) {
        player.GainBattleScore(scoreGain);
    }

    public override void Undo(Player player) {
        player.LoseBattleScore(scoreGain);
    }

}
