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

        // Reset each player's battle score and stack
        foreach (Player player in players) {
            player.battleScore = 0;
            player.battleScore = 0;
            player.ResetPlayedCards();
        }
        
        while (true) {
            // Determine first player by letting each player draw from the deck.
            GameObject playerACardObject = players[0].PlayCardFromDeck();
            GameObject playerBCardObject = players[1].PlayCardFromDeck();
            Card playerACard = playerACardObject?.GetComponent<Card>();
            Card playerBCard = playerBCardObject?.GetComponent<Card>();

            // No player has cards left in the deck
            if (playerACard == null && playerBCard == null) {
                // Draw
                // @TODO Transitition to game over state (Draw)
                Debug.Log("Neither player has any cards.");
                gameManager.SwitchState(gameManager.gameOverGameManagerState);
                break;
            }

            // Player A no longer has cards on the deck
            if (playerACard == null) {
                // @TODO Player B is the winner
                // @TODO Transition to game over state
                
                Debug.Log("Player A no longer has any cards.");
                gameManager.winningPlayer = players[1];
                gameManager.SwitchState(gameManager.gameOverGameManagerState);
                break;
            }

            // Player B no longer has cards on the deck
            if (playerBCard == null) {
                // @TODO Player A is the winner
                // @TODO Transition to game over state
                
                Debug.Log("Player B no longer has any cards.");
                gameManager.winningPlayer = players[0];
                gameManager.SwitchState(gameManager.gameOverGameManagerState);
                break;
            }

            // Get each card's value
            int playerACardValue = playerACard.GetValue();
            int playerBCardValue = playerBCard.GetValue();
            Debug.AssertFormat(playerACardValue > 0 && playerBCardValue > 0, "Player A or Player B's card value is expected to be greater than 0.");
            Debug.LogFormat("Getting from deck!({0} vs. {1})", playerACardValue, playerBCardValue);
            // Begin game
            // @TODO Transition to PlayerTurn state
            if (playerACardValue > playerBCardValue) {
                Debug.Log("Player A is first!");
                gameManager.currentPlayerIndex = 0;
                gameManager.SwitchState(gameManager.playerTurnGameManagerState);
                break;
            }

            if (playerACardValue < playerBCardValue) {
                Debug.Log("Player B is first!");
                gameManager.currentPlayerIndex = 1;
                gameManager.SwitchState(gameManager.playerTurnGameManagerState);
                break;
            }

            // Otherwise, the drawn cards are the same. Repeat the game setup phase.
            Debug.Log("Battle scores are the same.");

        }
    }

    public override void OnCardClick(GameManager gameManager, PlayingCard card) {
        return;
    }

    public override void OnCardActivation(GameManager gameManager, PlayingCard playingCard) {
        return;
    }

    public override void OnCardDeactivation(GameManager gameManager, PlayingCard card) {
        return;
    }

    public override void Update(GameManager gameManager) {
        //throw new NotImplementedException();
    }
}
