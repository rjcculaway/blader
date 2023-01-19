namespace Commands {
    public interface ICommand {
        void Execute(Player player);
        void Undo(Player player);
    }
}
