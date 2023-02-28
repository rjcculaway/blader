using UnityEngine;
using Commands;
public enum EffectTarget {
    Self,
    Enemy
}

public abstract class CardEffect : ScriptableObject, ICommand
{
    public EffectTarget effectTarget = EffectTarget.Self;

    public abstract void Execute(Player player);

    public abstract void Undo(Player player);
}
