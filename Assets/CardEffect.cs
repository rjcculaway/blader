using UnityEngine;
using Commands;
public enum EffectTarget {
    Self,
    Enemy
}

public class CardEffect : MonoBehaviour, ICommand
{
    public EffectTarget effectTarget = EffectTarget.Self;

    virtual public void Execute(Player player) {
        return;
    }

    virtual public void Undo(Player player) {
        return;
    }
}
