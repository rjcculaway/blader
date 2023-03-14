using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(UnityEngine.U2D.Animation.SpriteResolver))]
public class PlayingCard : MonoBehaviour {
    [SerializeField]
    private UnityEngine.U2D.Animation.SpriteResolver spriteResolver;
    private bool m_isFlipped = true;
    private bool isFlipped {
        get { return m_isFlipped; }
        set {
            if (m_isFlipped == value) return;
            m_isFlipped = value;
            UpdateDisplay();
        }
    }

    [SerializeField]
    private Card m_Card;
    public Card card {
        get { return m_Card; }
        set {
            if (m_Card == value) return;
            m_Card = value;
            UpdateDisplay();
        }
    }


    // Start is called before the first frame update
    void Start() {

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
    }

    // Initially, a PlayingCard does not have card-specific information in it.
    // This method applies a Card onto it, making it real.
    public void RealizePlayingCard(Card card) {
        if (this.card == null) {
            this.card = card;
            isFlipped = false;
            gameObject.SetActive(true);
            return;
        }
    }

    void OnMouseDown() {
        Flip();
    }
}
