using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Enumerate states
    public GameSetupGameManagerState gameSetupGameManagerState = new GameSetupGameManagerState();
    public PlayerTurnGameManagerState playerTurnGameManagerState = new PlayerTurnGameManagerState();

    public GameObject[] possibleCardPrefabs;
    [SerializeField] public Player[] players;
    public int currentPlayerIndex;
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
        List<GameObject> mainDeck = GenerateDeck();
        // Split the deck for each player.
        for (int i = 0; i < mainDeck.Count; i++) {
            GameObject cardObject = mainDeck[i];
            cardObject.SetActive(false);
            players[i % players.Length].ReceiveCard(cardObject);
        }

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
            Debug.Log(possibleCardPrefabs[ind]);
        }
        return deck;
    }

    public void OnCardActivation(PlayingCard playingCard) {
        currentState.OnCardActivation(playingCard);
    }

    void ApplyCard(Player source, PlayingCard playingCard) {
        //foreach (CardEffect cardEffect in playingCard.card.effects) { 
            
        //}
    }
}
