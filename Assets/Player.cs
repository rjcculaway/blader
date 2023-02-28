using Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int battleScore = 0;
    private List<PlayingCard> playingCards;
    private Transform[] cardSlots;

    public UnityEvent<Player, PlayingCard> cardActivation;

    private Stack<ICommand> playedCards;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveCard(PlayingCard card) {
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
}
