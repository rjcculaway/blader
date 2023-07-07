using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCard : Card {
    public IncreaseBattleScoreCardEffectProperties properties;

    public void Awake() {
        Player source = GetComponent<PlayingCard>().owner;
        effects = new List<CardEffect> {
            new IncreaseBattleScoreCardEffect(properties, source)
        };
    }
}
