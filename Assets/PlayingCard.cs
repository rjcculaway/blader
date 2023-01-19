using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;

public enum CardType { Diamond, Clubs, Spades, Hearts }
public enum CardColor { Blue, Red, Green, Yellow }

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(UnityEngine.U2D.Animation.SpriteResolver))]
public class PlayingCard : MonoBehaviour {
    [SerializeField]
    private UnityEngine.U2D.Animation.SpriteResolver spriteResolver;
    private bool isFlipped = false;

    [SerializeField]
    public List<CardEffect> effects;
    
    public CardType cardType;
    public CardColor cardColor;

    // Start is called before the first frame update
    void Start() {
        spriteResolver.SetCategoryAndLabel("FrontCard", cardType.ToString());
    }

    // Update is called once per frame
    void Update() {

    }

    void UpdateDisplay() {
        if (isFlipped) {
            spriteResolver.SetCategoryAndLabel("BackCard", cardColor.ToString());
        }
        else {
            spriteResolver.SetCategoryAndLabel("FrontCard", cardType.ToString());
        }
    }

    void Flip() {
        isFlipped = !isFlipped;
        UpdateDisplay();
    }
    
    void OnMouseDown() {
        Flip();
    }
}
