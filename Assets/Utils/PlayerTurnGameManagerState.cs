using System.Collections;
using UnityEngine;

public sealed class PlayerTurnGameManagerState : GameManagerBaseState {
    public PlayerTurnGameManagerState() : base() {
    }

    public override void Enter(GameManager gameManager) {
        Player activePlayer = gameManager.players[gameManager.currentPlayerIndex];
        activePlayer.ShowCards();
        for (int i = 0; i < gameManager.players.Length; i++) {
            Player player = gameManager.players[i];
            if (i != gameManager.currentPlayerIndex) {
                player.HideCards();
            }
        }
        return;
    }
    public override void Update(GameManager gameManager) {
        return;
    }

    public override void OnCardActivation(PlayingCard card) {
        return;
    }

}
