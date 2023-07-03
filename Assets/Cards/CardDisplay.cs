using Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum CardType { Diamond, Clubs, Spades, Hearts }
public enum CardColor { Blue, Red, Green, Yellow }

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class CardDisplay : ScriptableObject
{
    public CardType cardType;
    public CardColor cardColor;
 
    public int GetCardValue() {
        int cardValue = 0;
        //for (int i = 0; i < effects.Count; i++) {
        //    CardEffect effect = effects[i];
        //    if (effect.GetType() == typeof(IncreaseBattleScoreCardEffect)) {
        //        cardValue += (effect as IncreaseBattleScoreCardEffect).properties.scoreGain;
        //    }
        //}
        return cardValue;
    }
}
