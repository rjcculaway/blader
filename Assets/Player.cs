using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    const int MAX_CARDS = 10;
    public GameObject playingCardPrefab;

    private List<PlayingCard> playingCards = new List<PlayingCard>();
    [SerializeField]
    private Transform[] cardSlots;
    [SerializeField] private GameObject cardsParent;
    [SerializeField] private GameObject deckParent;

    private int m_battleScore = 0;
    public int battleScore {
        get { return m_battleScore; }
        set { 
            m_battleScore = value;
            battleScoreChanged.Invoke(battleScore);
            Debug.Log($"Your new battle score is {battleScore}");
        }
    }

    [SerializeField]
    private UnityEvent<int> battleScoreChanged;

    private Stack<GameObject> playerDeck = new Stack<GameObject>();
    private Stack<PlayingCard> playedCards = new Stack<PlayingCard>();

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveCard(GameObject cardObject) {
        PlayingCard playingCard = cardObject.GetComponent<PlayingCard>();
        playingCard.OwnPlayingCard(this);
        playingCards.Add(playingCard);

        foreach (Transform slot in cardSlots) { 
            if (slot.childCount <= 0) {
                cardObject.transform.SetPositionAndRotation(slot.position, slot.rotation);
                cardObject.transform.parent = slot.transform;
                cardObject.SetActive(true);
                return;
            }
        }

        playerDeck.Push(cardObject);
        cardObject.transform.parent = deckParent.transform;
        Debug.Log($"Player {gameObject?.name} received a card and moved to player deck.");
    }

    public GameObject DrawCardFromDeck() {
        Debug.Log($"Player Deck Size: {playerDeck.Count}");
        GameObject drawnCard;
        if (playerDeck.TryPop(out drawnCard)) {
            Debug.Log($"Player {gameObject?.name} has drawn the card {drawnCard?.name}");
            drawnCard.transform.parent = null;
        }

        return drawnCard;
    }

    public void PlaceCardOnHand(GameObject card) {
        foreach (Transform slot in cardSlots) {
            Debug.Log(slot.transform.childCount);
            if (slot.transform.childCount < 1) {
                card.transform.SetPositionAndRotation(slot.position, slot.rotation);
                card.transform.parent = slot.transform;
                card.SetActive(true);
            }
        }
    }

    public void GainBattleScore(int scoreGained) {
        battleScore += scoreGained;
    }

    public void LoseBattleScore(int scoreLost) {
        battleScore -= scoreLost;
    }

    public void PlayCard(PlayingCard card) {
        card.gameObject.SetActive(false);
        card.gameObject.transform.SetParent(null);
        playingCards.Remove(card);
        playedCards.Push(card);
        card.cardActivation.Invoke(card);

        GameObject drawnCard = DrawCardFromDeck();
        PlaceCardOnHand(drawnCard);

        return;
    }

    public void SetupTurn() {

    }
    public void ShowCards() {
        for (int i = 0; i < playingCards.Count; i++) {
            playingCards[i].ShowAndUpdateDisplay();
        }
    }

    public void HideCards() {
        for (int i = 0; i < playingCards.Count; i++) {
            playingCards[i].HideAndUpdateDisplay();
        }
    }

    public void ResetPlayedCards() {
        PlayingCard currentPlayingCard;
        while (playedCards.TryPop(out currentPlayingCard)) {
            currentPlayingCard.cardDeactivation.Invoke(currentPlayingCard);
        }
    }
}
