using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardDisplay cardDisplay;
    public List<CardEffect> effects;

    public int GetValue() {
        int value = 0;

        foreach (CardEffect effect in effects) {
            var increaseEffect = effect as IncreaseBattleScoreCardEffect;
            if (increaseEffect != null) {
                value += increaseEffect.properties.scoreGain;
            }
        }

        return value;
    }
}
