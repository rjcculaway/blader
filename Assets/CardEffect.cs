using UnityEngine;
using Commands;
using System;

public abstract class CardEffect : ICommand
{
    public abstract void Execute();

    public abstract void Undo();
}
