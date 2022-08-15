using UnityEngine;
using System;

public class Player_FlightController : FlightController
{
    private InputInfo inputInfo;
    private InteractableBike interactableBike;

    private bool isCombo;
    private float currentFlipAngle;
    private int comboCount;

    public event Action onIndicateComboSpeed;

    public void Init(InputInfo _inputInfo)
    {
        inputInfo = _inputInfo;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        interactableBike.onIndicateGroundMove += SetZeroCombo;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        interactableBike.onIndicateGroundMove -= SetZeroCombo;
    }

    protected override void Awake()
    {
        base.Awake();
        interactableBike = GetComponent<InteractableBike>();
    }

    protected override void Update()
    {
        base.Update();
        ControlFlip();
    }

    protected override void Flight()
    {
        if (inputInfo.IsPress)
            angularVelocity = Vector3.Lerp(angularVelocity, -transform.right * stuntMoveFactor, Time.deltaTime);
        else
            angularVelocity = Vector3.Lerp(angularVelocity, Vector3.zero, Time.deltaTime);

        rb.angularVelocity = angularVelocity;
    }

    private void ControlFlip()
    {
        float targetFlipAngle = 60f;
        currentFlipAngle = transform.localEulerAngles.x;

        if (!isCombo){
            if(Mathf.Abs(currentFlipAngle-targetFlipAngle) < 5f){
                comboCount++;
                isCombo = true;
                if(comboCount > 1)
                    IndicateComboSpeed();
            }
        }
        else
        {
            if(currentFlipAngle < 5f)
                isCombo = false;
        }
    }

    private void SetZeroCombo(float refTarget)
    {
        comboCount = 0;
    }

    private void IndicateComboSpeed()
    {
        if (onIndicateComboSpeed != null)
            onIndicateComboSpeed();
    }
}
