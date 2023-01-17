using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("Game Manager does not exist");
            }
            return _instance;
        }
    }

    [SerializeField]
    private Player[] players;
    private UnityEvent<Player, PlayingCard> cardActivation;

    void Start() {
        if (cardActivation == null) {
            cardActivation = new UnityEvent<Player, PlayingCard>();
        }
        // Cache players
        players = transform.gameObject.GetComponentsInChildren<Player>();
        Assert.IsTrue(players.Length > 0);
    }

    private void Awake() {
        _instance = this;
    }
}
