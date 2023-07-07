public abstract class GameManagerBaseState {

    public GameManagerBaseState() {
        
    }

    public abstract void Enter(GameManager gameManager);

    public abstract void Update(GameManager gameManager);

    public abstract void OnCardClick(GameManager gameManager, PlayingCard card);

    public abstract void OnCardActivation(GameManager gameManager, PlayingCard card);

    public abstract void OnCardDeactivation(GameManager gameManager, PlayingCard card);

}
