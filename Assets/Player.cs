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
    [SerializeField]
    private GameObject cardsParent;

    private List<GameObject> cardObjects = new List<GameObject>();

    public int battleScore = 0;


    public UnityEvent<Player, PlayingCard> cardActivation;

    private Stack<Card> playerDeck = new Stack<Card>();
    private Stack<ICommand> playedCards = new Stack<ICommand>();

    void Start()
    {
        // Prepare 10 game objects that will display card information
        for (int i = 0; i < MAX_CARDS; i++) {
            GameObject cardObject = Instantiate(playingCardPrefab);
            PlayingCard playingCard = cardObject.GetComponent<PlayingCard>();
            playingCards.Add(playingCard);
            cardObject.transform.SetPositionAndRotation(cardSlots[i].position, cardSlots[i].rotation);
            cardObject.transform.parent = cardsParent.transform;
            cardObject.SetActive(false);
            cardObjects.Add(cardObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveCard(Card card) {
        // Find the first free PlayingCard that can hold this Card information
        for (int i = 0; i < playingCards.Count; i++) {
            PlayingCard playingCard = playingCards[i];
            if (playingCard.card == null) {
                playingCard.RealizePlayingCard(card);
                return;
            }
        }
        // Otherwise, push onto player deck
        playerDeck.Push(card);
    }

    public void GainBattleScore(int scoreGained) {
        battleScore += scoreGained;
    }

    public void LoseBattleScore(int scoreLost) {
        battleScore -= scoreLost;
    }

    public void AcceptCardEffect(ICommand cardEffect) {
        cardEffect.Execute(this);
        playedCards.Push(cardEffect);
    }

    public void ActivateCard(PlayingCard playingCard) {
        cardActivation.Invoke(this, playingCard);
    }

    public void SetupTurn() {

    }
}
