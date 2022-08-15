using UnityEngine;
public class AI_FlightController : FlightController
{
    protected override void Flight()
    {
        if (!rb.isKinematic)
            angularVelocity = Vector3.Lerp(angularVelocity, -transform.right * stuntMoveFactor, Time.deltaTime);
        else
            angularVelocity = Vector3.Lerp(angularVelocity, Vector3.zero, Time.deltaTime);

        rb.angularVelocity = angularVelocity;
    }
}
