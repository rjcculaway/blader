using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Enumerate states
    GameSetupGameManagerState gameSetupGameManagerState = new GameSetupGameManagerState();
    PlayerTurnGameManagerState playerTurnGameManagerState = new PlayerTurnGameManagerState();

    public Card[] possibleCards;
    [SerializeField]
    public Player[] players;
    public int currentPlayerIndex;
    public uint deckSizePerPlayer = 16;
    private GameManagerBaseState currentState;

    void Awake() {
        Instance = this;
        currentState = gameSetupGameManagerState;
    }
    void Start() {
        SetupGame();
    }

    void SetupGame() {
        List<Card> mainDeck = GenerateDeck();
        // Split the deck for each player.
        for (int i = 0; i < mainDeck.Count; i++) {
            players[i % players.Length].ReceiveCard(mainDeck[i]);
        }

        //currentState.Enter(this);
    }

    private void Update() {
        currentState.Update(this);
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

    public void OnCardActivation(PlayingCard playingCard) {
        currentState.OnCardActivation(playingCard);
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
