using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverDisplayWinnerText : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI winnerTextMesh;
    
    public void SetWinnerText(string playerName) {
        if (playerName == null) {
            winnerTextMesh.text = "Draw!";
            return;
        }
        winnerTextMesh.text = $"{playerName} wins!";
    }
}
