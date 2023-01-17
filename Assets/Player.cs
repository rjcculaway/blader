using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int battleScore = 0;
    private List<PlayingCard> playingCards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void receiveCards(List<PlayingCard> playingCards) {
        this.playingCards = playingCards;
        return;
    }
}
