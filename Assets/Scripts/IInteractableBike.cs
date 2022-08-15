public interface IInteractableBike
{
    public void LandOnGround();
    public void Finish();
}

public interface IBikeInteractor<T> where T : IInteractableBike
{
    public void Interact(T interactableBike);
}
