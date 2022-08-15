using System.Collections;
using UnityEngine;

public class AI_SpeedController : SpeedController
{
    [SerializeField] private float arriveTime_to_topSpeed;
    private LandOnBehaviour landOnBehaviour;

    private float desiredMaxSpeed;
    private float usableMaxSpeed;

    protected override void Awake()
    {
        base.Awake();
        landOnBehaviour = GetComponent<LandOnBehaviour>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        GameManager.onStartGame += SetModifyingSpeed;
        landOnBehaviour.onIndicateSpeedUpBehaviour += SetModifyingSpeed;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.onStartGame -= SetModifyingSpeed;
        landOnBehaviour.onIndicateSpeedUpBehaviour -= SetModifyingSpeed;
    }

    private void Start()
    {
        desiredMaxSpeed = maxSpeed;
    }

    private void Update()
    {
        if (!modifiableSpeed)
            SpeedDown(speedDownFactor * failDownFactor);
        else if (_isFlight)
            SpeedDown(speedDownFactor);

        SetSpeed();
    }

    private void SetModifyingSpeed()
    {
        if (modifiableSpeed)
            StartCoroutine(ModifySpeed(arriveTime_to_topSpeed));
    }

    private IEnumerator ModifySpeed(float completeInSeconds)
    {
        usableMaxSpeed = Random.Range(desiredMaxSpeed - 7.5f, desiredMaxSpeed + 7.5f);
        float startSpeed = speed;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / completeInSeconds;
            speed = Mathf.Lerp(startSpeed, usableMaxSpeed, t);
            yield return null;
        }
        yield break;
    }
}
