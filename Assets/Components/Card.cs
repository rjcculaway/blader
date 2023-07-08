using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardDisplay cardDisplay;
    public List<CardEffect> effects;

    public int GetValue() {
        int value = 0;
        bool foundIncreaseEffect = false;

        foreach (CardEffect effect in effects) {
            var increaseEffect = effect as IncreaseBattleScoreCardEffect;
            if (increaseEffect != null) {
                foundIncreaseEffect = true;
                value += increaseEffect.properties.scoreGain;
            }
        }

        // If the card has no IncreaseBattleScoreCardEffect, the value of the card is 1.
        if (!foundIncreaseEffect) {
            value = 1;
        }

        return value;
    }

    public void ActivateEffects(GameManager gameManager) {
        foreach (CardEffect effect in effects) {
            effect.Execute();
        }
    }

    public void DeactivateEffects(GameManager gameManager) {
        foreach (CardEffect effect in effects) {
            effect.Undo();
        }
    }

    public void OwnCard(Player source) {
        foreach(CardEffect effect in effects) {
            effect.source = source;
        }
    }
}
