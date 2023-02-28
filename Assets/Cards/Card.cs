using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { Diamond, Clubs, Spades, Hearts }
public enum CardColor { Blue, Red, Green, Yellow }

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public CardType cardType;
    public CardColor cardColor;

    public List<CardEffect> effects;
}
