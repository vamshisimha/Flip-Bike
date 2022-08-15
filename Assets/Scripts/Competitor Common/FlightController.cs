using UnityEngine;

public abstract class FlightController : MonoBehaviour
{
    protected Rigidbody rb;
    protected OnPathBehaviour onPathBehaviour;

    [SerializeField] protected float stuntMoveFactor;
    protected Vector3 angularVelocity;

    protected virtual void OnEnable()
    {
        onPathBehaviour.onIndicateFlight += OpenPhysicsBody;
        onPathBehaviour.onIndicateClosePhysics += ClosePhysicsBody;
    }

    protected virtual void OnDisable()
    {
        onPathBehaviour.onIndicateFlight -= OpenPhysicsBody;
        onPathBehaviour.onIndicateClosePhysics -= ClosePhysicsBody;
    }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        onPathBehaviour = GetComponent<OnPathBehaviour>();
    }

    protected virtual void Update()
    {
        Flight();
    }

    protected abstract void Flight();

    protected virtual void OpenPhysicsBody(float flightVelocity)
    {
        rb.isKinematic = false;
        rb.velocity = transform.forward * flightVelocity;
    }

    protected virtual void ClosePhysicsBody()
    {
        rb.isKinematic = true;
    }
}
