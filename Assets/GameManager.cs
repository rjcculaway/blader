using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Enumerate states
    public GameSetupGameManagerState gameSetupGameManagerState = new GameSetupGameManagerState();
    public PlayerTurnGameManagerState playerTurnGameManagerState = new PlayerTurnGameManagerState();
    public GameOverGameManagerState gameOverGameManagerState = new GameOverGameManagerState();

    public GameObject[] possibleCardPrefabs;
    public GameObject gameOverUiPrefab;
    public Player[] players;
    public int currentPlayerIndex;
    public Player winningPlayer;
    public const uint deckSizePerPlayer = 16;
    private GameManagerBaseState currentState;

    void Awake() {
        Instance = this;
        currentState = gameSetupGameManagerState;
    }
    void Start() {
        SetupGame();
    }

    void SetupGame() {
        winningPlayer = null;
        List<GameObject> mainDeck = GenerateDeck();
        // Split the deck for each player.
        for (int i = 0; i < mainDeck.Count; i++) {
            GameObject cardObject = mainDeck[i];
            cardObject.SetActive(false);
            players[i % players.Length].ReceiveCard(cardObject);
        }

        currentState = gameSetupGameManagerState;
        currentState.Enter(this);
    }

    private void Update() {
        currentState.Update(this);
    }

    public void SwitchState (GameManagerBaseState state) {
        currentState = state;
        currentState.Enter(this);
    }

    List<GameObject> GenerateDeck() {
        List<GameObject> deck = new List<GameObject>();
        // Randomly select from the possible cards.
        for (uint i = 0; i < deckSizePerPlayer * 2; i++) {
            int ind = Mathf.RoundToInt(Random.value * (possibleCardPrefabs.Length - 1));

            deck.Add(Instantiate(possibleCardPrefabs[ind]));
        }
        return deck;
    }

    public void OnCardClick(PlayingCard playingCard) {
        currentState.OnCardClick(this, playingCard);
    }

    public void OnCardActivation(PlayingCard playingCard) {
        currentState.OnCardActivation(this, playingCard);
        return;
    }

    public void OnCardDeactivation(PlayingCard playingCard) {
        currentState.OnCardDeactivation(this, playingCard);
    }

    public Player GetActivePlayer() {
        Assert.IsNotNull(players[currentPlayerIndex]);
        return players[currentPlayerIndex];
    }

    public Player GetWaitingPlayer() {
        Player otherPlayer = null;
        Player activePlayer = GetActivePlayer();
        foreach (Player player in players) {
            if (player != activePlayer) {
                otherPlayer = player;
                break;
            }
        }
        Assert.IsNotNull(otherPlayer);
        return otherPlayer;
    }

    public void NextPlayer () {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
    }

    public void InstantiateGameOverScreen() {
        Instantiate(gameOverUiPrefab, gameObject.transform.parent);
    }
}
