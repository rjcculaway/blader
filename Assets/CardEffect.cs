using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;

public class PlayerEffect : IPlayerCommand {
    public void execute(Player player) {
        return;
    }

    public void undo (Player player) {
        return;
    }
}

public enum EffectTarget {
    Player,
    Enemy
}

public class CardEffect : MonoBehaviour
{
    public EffectTarget effectTarget = EffectTarget.Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
