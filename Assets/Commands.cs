using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands {
    public interface IPlayerCommand {
        void execute(Player player);
        void undo(Player player);
    }
}
