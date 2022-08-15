using Dreamteck.Splines;
using UnityEngine;
using System;
using System.Collections;

public class OnPathBehaviour : MonoBehaviour
{
    protected SplineFollower splineFollower;
    protected SplineProjector splineProjector;
    protected InteractableBike interactableBike;
    protected Collider _collider;

    protected int currentRowIndex;
    [SerializeField] private PathInfo[] pathInfos;
    protected int currentTrackIndex;

    public event Action onIndicateClosePhysics;
    public event Action<float> onIndicateFlight;

    protected virtual void OnEnable()
    {
        interactableBike.onIndicateGroundMove += Enter_to_Path;
        LevelManager.onIndicateLevelIndex += SetTrack;
    }

    protected virtual void OnDisable()
    {
        interactableBike.onIndicateGroundMove -= Enter_to_Path;
        LevelManager.onIndicateLevelIndex -= SetTrack;
    }

    protected virtual void Awake() 
    {
        splineFollower = GetComponent<SplineFollower>();
        splineProjector = GetComponent<SplineProjector>();
        interactableBike = GetComponent<InteractableBike>();
        _collider = GetComponent<Collider>();
    }

    protected virtual void SetTrack(int targetTrackIndex)
    {
        currentTrackIndex = targetTrackIndex;
        SetUsableRow();
    }

    protected virtual void SetUsableRow() 
    {
        splineFollower.spline = pathInfos[currentTrackIndex].splines[currentRowIndex];
        splineProjector.spline = pathInfos[currentTrackIndex].splines[currentRowIndex];
    }

    protected virtual void Enter_to_Path(float refX)
    {
        _collider.enabled = false;
        splineFollower.enabled = true;
        splineFollower.SetPercent(splineProjector.GetPercent());
        IndicateClosePhysics();
    }

    protected virtual void Exit_from_Path()
    {
        splineFollower.enabled = false;
        StartCoroutine(OpenInteracting());

        int trackRowLength = pathInfos[currentTrackIndex].splines.Length;
        if (currentRowIndex < trackRowLength && currentRowIndex != trackRowLength - 1)
        {
            currentRowIndex++;
            SetUsableRow();
        }
    }

    private IEnumerator OpenInteracting()
    {
        yield return new WaitForSeconds(0.1f);
        _collider.enabled = true;
    }

    protected virtual void ControllingEnd_of_Path()
    {
        if (splineFollower.enabled)
        {
            Vector3 endPos = splineFollower.EvaluatePosition(1);
            float dist = Vector3.SqrMagnitude(endPos - transform.position);

            if (dist < .01f)
            {
                Exit_from_Path();
                IndicateFlight(splineFollower.followSpeed);
            }
        }
    }

    protected virtual void Update()
    {
        ControllingEnd_of_Path();
    }

    protected virtual void IndicateClosePhysics()
    {
        if (onIndicateClosePhysics != null)
            onIndicateClosePhysics();
    }

    protected virtual void IndicateFlight(float targetFlightVelocity)
    {
        if (onIndicateFlight != null)
            onIndicateFlight(targetFlightVelocity);
    }
}
