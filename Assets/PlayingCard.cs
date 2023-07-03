using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;
using UnityEngine.Events;

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
        }
    }
    private Player m_owner;
    public Player owner {
        get {
            return m_owner;
        }
    }
    public UnityEvent<PlayingCard> cardActivation;

    public Card card;

    private void Awake() {
        cardActivation.AddListener(GameManager.Instance.OnCardActivation);
    }

    void UpdateDisplay() {
        if (isFlipped) {
            spriteResolver.SetCategoryAndLabel("BackCard", card.cardDisplay.cardColor.ToString());
        }
        else {
            spriteResolver.SetCategoryAndLabel("FrontCard", card.cardDisplay.cardType.ToString());
        }
    }

    void SetCardAndUpdateDisplay(Card card) {
        this.card = card;
        UpdateDisplay();
    }

    public void FlipAndUpdateDisplay() {
        isFlipped = !isFlipped;
        UpdateDisplay();
    }

    public void HideAndUpdateDisplay() {
        isFlipped = true;
        UpdateDisplay();
    }

    public void ShowAndUpdateDisplay() {
        isFlipped = false;
        UpdateDisplay();
    }

    public void OwnPlayingCard(Player player) {
        m_owner = player;
    }

    void OnMouseDown() {
        cardActivation.Invoke(this);
    }
}
