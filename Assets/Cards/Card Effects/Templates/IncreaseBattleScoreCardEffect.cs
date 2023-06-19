using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIncreaseBattleScoreCardEffect", menuName = "Card Effects/Increase Battle Score")]
public class IncreaseBattleScoreCardEffect : CardEffect
{
    [SerializeField]
    private int m_scoreGain;
    public int scoreGain {
        get {
            return m_scoreGain;
        }
    }

    public override void Execute(Player player) {
        player.GainBattleScore(m_scoreGain);
    }

    public override void Undo(Player player) {
        player.LoseBattleScore(m_scoreGain);
    }

}
