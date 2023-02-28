using Commands;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
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
        // Cache players
        players = transform.gameObject.GetComponentsInChildren<Player>();
        Assert.IsTrue(players.Length > 0);
        foreach (Player player in players) {
            SubscribeToPlayer(player.cardActivation);
        }
        SetupGame();
    }

    void SetupGame() {
        List<PlayingCard> mainDeck = GenerateDeck();
        for (int i = 0; i < mainDeck.Count; i++) {
            players[i % players.Length].ReceiveCard(mainDeck[i]);
        }
    }

    List<PlayingCard> GenerateDeck() {
        List<PlayingCard> deck = new List<PlayingCard>();
        for (uint i = 0; i < deckSizePerPlayer * 2; i++) {
            //deck.Add();
        }
        Mathf.FloorToInt(Random.Range(0, 3));
        return deck;
    }

    void SubscribeToPlayer(UnityEvent<Player, PlayingCard> unityEvent) {
        unityEvent.AddListener(OnCardActivation);
    }

    void OnCardActivation(Player source, PlayingCard playingCard) {
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
