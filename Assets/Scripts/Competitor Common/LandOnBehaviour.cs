using Dreamteck.Splines;
using UnityEngine;
using System.Collections;
using System;

public class LandOnBehaviour : MonoBehaviour
{
    private InteractableBike interactableBike;
    private SplineFollower splineFollower;

    private float xRot;

    public event Action onIndicateSpeedUpBehaviour;

    private void OnEnable()
    {
        interactableBike.onIndicateGroundMove += Start_to_OriginRot;
    }

    private void OnDisable()
    {
        interactableBike.onIndicateGroundMove -= Start_to_OriginRot;
    }

    private void Awake()
    {
        splineFollower = GetComponent<SplineFollower>();
        interactableBike = GetComponent<InteractableBike>();
    }

    private void Update()
    {
        Turn();
    }

    private void Turn()
    {
        splineFollower.motion.rotationOffset = new Vector3(xRot, 0, 0);
    }

    private void Start_to_OriginRot(float targetX)
    {
        xRot = targetX;
        StartCoroutine(ModifyingRot(0.1f));
    }

    private IEnumerator ModifyingRot(float completeInSeconds)
    {
        float startRot = xRot;

        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / completeInSeconds;
            xRot = Mathf.Lerp(startRot, 0, t);
            yield return null;
        }
        IndicateSpeedUpBehaviour();
        yield break;
    }

    private void IndicateSpeedUpBehaviour()
    {
        if (onIndicateSpeedUpBehaviour != null)
            onIndicateSpeedUpBehaviour();
    }
}
