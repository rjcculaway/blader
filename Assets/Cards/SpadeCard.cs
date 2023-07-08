using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpadeCard : Card {
    public IncreaseBattleScoreCardEffectProperties properties;

    public void Awake() {
        Player source = GetComponent<Player>();
        effects = new List<CardEffect> {
            new IncreaseBattleScoreCardEffect(properties, source)
        };
    }
}
