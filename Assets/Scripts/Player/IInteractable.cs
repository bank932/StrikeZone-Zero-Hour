namespace StrikeZone.Player
{
    public interface IInteractable
    {
        string GetInteractionText();

        bool CanInteract();

        bool Interact(GamePlayerInteractor interactor);
    }
}
