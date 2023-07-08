using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameOverGameManagerState : GameManagerBaseState
{
    public override void Enter(GameManager gameManager) {
        foreach (Player player in gameManager.players) {
            player.ShowCards();
        }
        gameManager.InstantiateGameOverScreen();
        return;
    }

    public override void OnCardActivation(GameManager gameManager, PlayingCard card) {
        return;
    }

    public override void OnCardClick(GameManager gameManager, PlayingCard card) {
        return;
    }

    public override void OnCardDeactivation(GameManager gameManager, PlayingCard card) {
        return;
    }

    public override void Update(GameManager gameManager) {
        return;
    }
}
