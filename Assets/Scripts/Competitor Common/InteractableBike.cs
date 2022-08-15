using UnityEngine;
using System;

public abstract class InteractableBike : MonoBehaviour, IInteractableBike
{
    public event Action<float> onIndicateGroundMove;
    public event Action onIndicate_RagdollFalling;
    public event Action onIndicateFinishLine;

    protected Collider _collider;
    protected bool isFinished;
    [SerializeField] protected float targetFallingNumerical;

    protected GameManager gameManager;

    public virtual void Init(GameManager _gameManager)
    {
        gameManager = _gameManager;
    }

    protected virtual void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    protected bool IsFalling()
    {
        Vector3 bikeForward = transform.forward;
        Vector3 worldForward = new Vector3(0, 0, 1);

        if (Vector3.Dot(bikeForward, worldForward) < targetFallingNumerical)
            return true;

        return false;
    }

    public abstract void LandOnGround();

    public abstract void Finish();

    protected virtual void IndicateGroundMove(float landingX)
    {
        if (onIndicateGroundMove != null)
            onIndicateGroundMove(landingX);
    }

    protected virtual void Indicate_RagdollFalling()
    {
        _collider.enabled = false;
        if (onIndicate_RagdollFalling != null)
            onIndicate_RagdollFalling();
    }

    protected virtual void FinishLine() 
    {
        if (onIndicateFinishLine != null)
            onIndicateFinishLine();
    }
}
