using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum CardType { Diamond, Clubs, Spades, Hearts }
public enum CardColor { Blue, Red, Green, Yellow }

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public CardType cardType;
    public CardColor cardColor;

    public int GetCardValue() {
        int cardValue = 0;
        for (int i = 0; i < effects.Count; i++) {
            CardEffect effect = effects[i];
            if (GetType() == typeof(IncreaseBattleScoreCardEffect)) {
                cardValue += (effect as IncreaseBattleScoreCardEffect).scoreGain;
            }
        }
        return cardValue;
    }

    public List<CardEffect> effects;
}
