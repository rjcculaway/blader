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
    public GameObject playingCardPrefab;

    void Start() {
        SetupGame();
    }

    void SetupGame() {
        List<Card> mainDeck = GenerateDeck();
        for (int i = 0; i < mainDeck.Count; i++) {
            players[i % players.Length].ReceiveCard(mainDeck[i]);
        }
        // Fabricate PlayingCard game objects for each player
        foreach (Player player in players) {
            for (int i = 0; i < 10; i++) {
                player.ReceivePlayingCard(Instantiate(playingCardPrefab), i);
            }
        }
    }

    List<Card> GenerateDeck() {
        List<Card> deck = new List<Card>();
        for (uint i = 0; i < deckSizePerPlayer * 2; i++) {
            deck.Add(possibleCards[Mathf.FloorToInt(Random.value * (possibleCards.Length - 1))]);
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
