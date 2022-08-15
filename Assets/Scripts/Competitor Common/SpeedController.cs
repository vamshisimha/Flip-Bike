using Dreamteck.Splines;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    protected InteractableBike interactableBike;
    protected SplineFollower splineFollower;
    protected OnPathBehaviour onPathBehaviour;

    //User Parameters
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float speedDownFactor;

    protected float failDownFactor;

    protected float speed;

    protected bool isSpeedUp;
    protected bool modifiableSpeed;
    protected bool _isFlight;
    public bool IsFlight
    {
        get
        {
            return _isFlight;
        }
        set
        {
            _isFlight = value;
        }
    }

    protected virtual void OnEnable()
    {
        onPathBehaviour.onIndicateFlight += SetFlightBehaviour;
        onPathBehaviour.onIndicateClosePhysics += SetSplineBehaviour;
        interactableBike.onIndicate_RagdollFalling += CloseModifiableSpeed;
        interactableBike.onIndicateFinishLine += CloseModifiableSpeed;
        GameManager.onStartGame += SetModifiableSpeed;
    }

    protected virtual void OnDisable()
    {
        onPathBehaviour.onIndicateFlight -= SetFlightBehaviour;
        onPathBehaviour.onIndicateClosePhysics -= SetSplineBehaviour;
        interactableBike.onIndicate_RagdollFalling -= CloseModifiableSpeed;
        interactableBike.onIndicateFinishLine -= CloseModifiableSpeed;
        GameManager.onStartGame -= SetModifiableSpeed;
    }

    protected virtual void Awake()
    {
        splineFollower = GetComponent<SplineFollower>();
        interactableBike = GetComponent<InteractableBike>();
        onPathBehaviour = GetComponent<OnPathBehaviour>();
    }

    protected virtual void SetSpeed()
    {
        speed = Mathf.Clamp(speed, 0, maxSpeed);
        splineFollower.followSpeed = speed;
    }

    protected virtual void SpeedDown(float targetFactor)
    {
        speed -= Time.deltaTime * targetFactor;
    }

    protected virtual void SetFlightBehaviour(float refTarget)
    {
        _isFlight = true;
    }

    protected virtual void SetSplineBehaviour()
    {
        _isFlight = false;
    }

    protected virtual void SetModifiableSpeed()
    {
        modifiableSpeed = true;
    }

    protected virtual void CloseModifiableSpeed()
    {
        failDownFactor = speed / 1.5f;
        modifiableSpeed = false;
    }
}
