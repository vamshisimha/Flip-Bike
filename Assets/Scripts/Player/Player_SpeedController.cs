using UnityEngine;
using System.Collections;

public class Player_SpeedController : SpeedController
{
    [SerializeField] private float maxSpeedFactor;
    private float speedFactor;

    private Player_FlightController flightController;

    protected override void OnEnable()
    {
        base.OnEnable();
        InputInfo.onPressDown += SetSpeedFactor;
        InputInfo.onPressDown += SetSpeedUp;
        InputInfo.onPressUp += SetSpeedDown;
        GameManager.onFailGame += SpeedDown_to_Over;
        flightController.onIndicateComboSpeed += ComboSpeed;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        InputInfo.onPressDown -= SetSpeedFactor;
        InputInfo.onPressDown -= SetSpeedUp;
        InputInfo.onPressUp -= SetSpeedDown;
        GameManager.onFailGame -= SpeedDown_to_Over;
        flightController.onIndicateComboSpeed -= ComboSpeed;
    }

    protected override void Awake()
    {
        base.Awake();
        flightController = GetComponent<Player_FlightController>();
    }

    private void Update()
    {
        if (modifiableSpeed)
        {
            if (isSpeedUp && !_isFlight)
                SpeedUp();
            else
                SpeedDown(speedDownFactor);
        }
        else
            SpeedDown(speedDownFactor * failDownFactor);

        SetSpeed();
    }

    private void ComboSpeed()
    {
        speedDownFactor += .25f;
        maxSpeed += 2.5f;
    }

    private void SetSpeedUp()
    {
        isSpeedUp = true;
    }

    private void SetSpeedDown()
    {
        isSpeedUp = false;
    }

    private void SpeedUp()
    {
        speed += Time.deltaTime * speedFactor;
    }

    private void SpeedDown_to_Over() 
    {
        CloseModifiableSpeed();
    }

    //Cubic Ease In Function
    private IEnumerator ModifySpeedFactor(float completeInSeconds)
    {
        speedFactor = 0;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / completeInSeconds;
            speedFactor = maxSpeedFactor * t * t * t;
            yield return null;
        }
        yield break;
    }

    private void SetSpeedFactor()
    {
        StartCoroutine(ModifySpeedFactor(.25f));
    }
}
