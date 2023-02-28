using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(UnityEngine.U2D.Animation.SpriteResolver))]
public class PlayingCard : MonoBehaviour {
    [SerializeField]
    private UnityEngine.U2D.Animation.SpriteResolver spriteResolver;
    private bool isFlipped = false;

    [SerializeField]
    public Card card;

    // Start is called before the first frame update
    void Start() {
        spriteResolver.SetCategoryAndLabel("FrontCard", card.cardType.ToString());
    }

    // Update is called once per frame
    void Update() {

    }

    void UpdateDisplay() {
        if (isFlipped) {
            spriteResolver.SetCategoryAndLabel("BackCard", card.cardColor.ToString());
        }
        else {
            spriteResolver.SetCategoryAndLabel("FrontCard", card.cardType.ToString());
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
