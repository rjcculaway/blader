using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;

public enum CardType { Diamond, Clubs, Spades, Hearts }
public enum CardColor { Blue, Red, Green, Yellow }

public class PlayingCard : MonoBehaviour {
    [SerializeField]
    private UnityEngine.U2D.Animation.SpriteResolver spriteResolver;
    private bool isFlipped = false;
    private bool isActivated = true;

    public CardEffect effect;
    
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

    void Deactivate() {
        isActivated = false;
    }

    void Activate() {
        isActivated = true;
    }
    
    void OnMouseDown() {
        Flip();
    }
}
