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

    private List<GameObject> cardObjects = new List<GameObject>();

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

        if (cardObjects.Count >= cardSlots.Length) {
            playerDeck.Push(cardObject);
            cardObject.transform.parent = deckParent.transform;
            Debug.Log("Card moved to player deck.");
        } else {
            cardObject.transform.SetPositionAndRotation(cardSlots[cardObjects.Count].position, cardSlots[cardObjects.Count].rotation);
            cardObject.transform.parent = cardsParent.transform;
            cardObject.SetActive(true);
            cardObjects.Add(cardObject);
        }


    }

    public void GainBattleScore(int scoreGained) {
        battleScore += scoreGained;
    }

    public void LoseBattleScore(int scoreLost) {
        battleScore -= scoreLost;
    }

    public GameObject PlayCardFromDeck() {
        GameObject playingCardFromDeck;
        if (playerDeck.TryPop(out playingCardFromDeck)) {
            return playingCardFromDeck;
        } else {
            return null;
        }
    }

    public void PlayCard(PlayingCard card) {
        card.gameObject.SetActive(false);
        playingCards.Remove(card);
        cardObjects.Remove(card.gameObject);
        playedCards.Push(card);
        card.cardActivation.Invoke(card);
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
