using System.Collections.Generic;

public class ClubCard : Card
{
    public IncreaseBattleScoreCardEffectProperties properties;

    public void Awake() {
        Player source = GetComponent<PlayingCard>().owner;
        effects = new List<CardEffect> {
            new IncreaseBattleScoreCardEffect(properties, source)
        };
    }
}
