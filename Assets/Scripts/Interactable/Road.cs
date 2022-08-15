using UnityEngine;

public class Road : MonoBehaviour, IBikeInteractor<InteractableBike>
{
    private void OnTriggerEnter(Collider collision)     
    {
        if (collision.transform.TryGetComponent(out InteractableBike interactableBike))
            Interact(interactableBike);
    }

    public void Interact(InteractableBike _interactableBike)
    {
        _interactableBike.LandOnGround();
    }
}
