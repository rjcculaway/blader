using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManagerBaseState {

    public GameManagerBaseState() {
        
    }

    public abstract void Enter(GameManager gameManager);

    public abstract void Update(GameManager gameManager);

    public abstract void OnCardActivation(PlayingCard card);

}
