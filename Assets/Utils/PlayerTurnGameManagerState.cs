using UnityEngine;
public sealed class PlayerTurnGameManagerState : GameManagerBaseState {
    public PlayerTurnGameManagerState() : base() {
    }

    public override void Enter(GameManager gameManager) {
        Player activePlayer = gameManager.GetActivePlayer();
        activePlayer.ShowCards();

        Player otherPlayer = gameManager.GetWaitingPlayer();
        otherPlayer.HideCards();

        return;
    }
    public override void Update(GameManager gameManager) {
        return;
    }

    public override void OnCardClick(GameManager gameManager, PlayingCard playingCard) {
        Player activePlayer = gameManager.GetActivePlayer();
        // The current player should only be able to interact with their own cards.
        if (playingCard.owner == activePlayer) {
            Debug.Log(playingCard.owner.gameObject.name);
            activePlayer.PlayCard(playingCard);
            EvaluateGame(gameManager);
        }
        return;
    }

    private void EvaluateGame(GameManager gameManager) {

        Player activePlayer = gameManager.GetActivePlayer();
        Player otherPlayer = gameManager.GetWaitingPlayer();

        if (activePlayer.battleScore > otherPlayer.battleScore) {
            gameManager.NextPlayer();
            gameManager.SwitchState(gameManager.playerTurnGameManagerState);
            return;
        }

        if (otherPlayer.battleScore > activePlayer.battleScore) {
            gameManager.winningPlayer = otherPlayer;
            gameManager.SwitchState(gameManager.gameOverGameManagerState);
            return;
        }

        gameManager.SwitchState(gameManager.gameSetupGameManagerState);

    }

    public override void OnCardActivation(GameManager gameManager, PlayingCard playingCard) {
        playingCard.card.ActivateEffects(gameManager);
    }

    public override void OnCardDeactivation(GameManager gameManager, PlayingCard playingCard) {
        playingCard.card.DeactivateEffects(gameManager);
    }
}
