using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int battleScore = 0;
    private List<Card> playingCards = new List<Card>();
    [SerializeField]
    private Transform[] cardSlots;
    [SerializeField]
    private GameObject cardsParent;

    public UnityEvent<Player, PlayingCard> cardActivation;

    private Stack<ICommand> playedCards;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceivePlayingCard(GameObject playingCard, int slot) {
        playingCard.transform.SetPositionAndRotation(cardSlots[slot].position, cardSlots[slot].rotation);
        playingCard.transform.parent = cardsParent.transform;
        playingCard.SetActive(true);
    }

    public void ReceiveCard(Card card) {
        playingCards.Add(card);
        
        return;
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
