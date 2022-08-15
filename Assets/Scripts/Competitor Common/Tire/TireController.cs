using Dreamteck.Splines;
using UnityEngine;

public class TireController : MonoBehaviour
{
    [SerializeField] protected SplineFollower splineFollower;

    protected float turnSpeed;
    protected float xRot;
    [SerializeField] protected float speedFactor;

    protected virtual void Update()
    {
        Turn();
    }

    protected virtual void Turn()
    {
        turnSpeed = splineFollower.followSpeed * speedFactor;
        xRot += turnSpeed;
        transform.localEulerAngles = new Vector3(xRot, 0, 0);
    }
}
