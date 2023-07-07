using UnityEngine;
using Commands;
using System;

public abstract class CardEffect : ICommand
{
    public Player source;
    public abstract void Execute();

    public abstract void Undo();
}
