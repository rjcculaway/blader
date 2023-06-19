using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public sealed class GameSetupGameManagerState : GameManagerBaseState
{

    public GameSetupGameManagerState(): base() {
        
    }

    public override void Enter(GameManager gameManager) {
        Player[] players = gameManager.players;
        while (true) {
            // Determine first player by letting each player draw from the deck.
            Card playerACard = players[0].PlayCardFromDeck();
            Card playerBCard = players[1].PlayCardFromDeck();

            // No player has cards left in the deck
            if (playerACard == null && playerBCard == null) {
                // Draw
                // @TODO Transitition to game over state (Draw)
                throw new NotImplementedException();
                break;
            }

            // Player A no longer has cards on the deck
            if (playerACard == null) {
                // @TODO Player B is the winner
                // @TODO Transition to game over state
                throw new NotImplementedException();
                break;
            }

            // Player B no longer has cards on the deck
            if (playerBCard == null) {
                // @TODO Player A is the winner
                // @TODO Transition to game over state
                throw new NotImplementedException();
                break;
            }

            // Get each card's value
            int playerACardValue = playerACard.GetCardValue();
            int playerBCardValue = playerBCard.GetCardValue();

            // Begin game
            // @TODO Transition to PlayerTurn state
            if (playerACardValue > playerBCardValue) {
                throw new NotImplementedException();
                break;
            }

            if (playerACardValue < playerBCardValue) {
                throw new NotImplementedException();
                break;
            }

            // Otherwise, the drawn cards are the same. Repeat the game setup phase.

        }
    }

    public override void OnCardActivation(PlayingCard card) {
        throw new NotImplementedException();
    }

    public override void Update(GameManager gameManager) {
        //throw new NotImplementedException();
    }
}
