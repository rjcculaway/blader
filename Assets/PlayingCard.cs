using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingCard : MonoBehaviour {
    public UnityEngine.U2D.Animation.SpriteResolver spriteResolver;
    private bool isFlipped = false;
    private string cardType;

    // Start is called before the first frame update
    void Start() {
        cardType = spriteResolver.GetLabel();
    }

    // Update is called once per frame
    void Update() {

    }

    void UpdateDisplay() {
        if (isFlipped) {
            spriteResolver.SetCategoryAndLabel("BackCard", "Blue");
        }
        else {
            spriteResolver.SetCategoryAndLabel("FrontCard", cardType);
        }
    }

    private void OnMouseDown() {
        isFlipped = !isFlipped;
        UpdateDisplay();
    }
}
