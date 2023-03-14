using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Card[] possibleCards;
    [SerializeField]
    private Player[] players;
    public uint deckSizePerPlayer = 16;

    void Start() {
        SetupGame();
    }

    void SetupGame() {
        List<Card> mainDeck = GenerateDeck();
        // Split the deck for each player.
        for (int i = 0; i < mainDeck.Count; i++) {
            players[i % players.Length].ReceiveCard(mainDeck[i]);
        }
    }

    List<Card> GenerateDeck() {
        List<Card> deck = new List<Card>();
        // Randomly select from the possible cards.
        for (uint i = 0; i < deckSizePerPlayer * 2; i++) {
            int ind = Mathf.RoundToInt(Random.value * (possibleCards.Length - 1));
            deck.Add(possibleCards[ind]);
        }
        return deck;
    }

    public void OnCardActivation(Player source, PlayingCard playingCard) {
        ApplyCard(source, playingCard);
    }

    void ApplyCard(Player source, PlayingCard playingCard) {
        foreach (CardEffect cardEffect in playingCard.card.effects) {
            foreach (Player player in players) {
                if (cardEffect.effectTarget == EffectTarget.Enemy && player != source) {
                    player.AcceptCardEffect(cardEffect);
                }
                if (cardEffect.effectTarget == EffectTarget.Self && player == source) {
                    player.AcceptCardEffect(cardEffect);
                }
            }
        }
    }
}
