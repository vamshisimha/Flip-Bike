using UnityEngine;

public class FinishLine : MonoBehaviour, IBikeInteractor<InteractableBike>
{
    private void OnTriggerEnter(Collider collision) 
    {
        if (collision.transform.TryGetComponent(out InteractableBike interactableBike))
            Interact(interactableBike);
    }

    public void Interact(InteractableBike _interactableBike)
    {
        _interactableBike.Finish();
    }
}
