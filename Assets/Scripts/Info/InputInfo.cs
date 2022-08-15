using UnityEngine;
using System;

public class InputInfo : MonoBehaviour
{
    public static event Action onPressDown;
    public static event Action onPressUp;

    private bool _isPress;
    public bool IsPress
    {
        get
        {
            return _isPress;
        }
        set
        {
            _isPress = value;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Press();

        if (Input.GetMouseButtonUp(0))
            PressUp();

        _isPress = Input.GetMouseButton(0);
    }

    public void Press()
    {
        if (onPressDown != null)
            onPressDown();
    }

    public void PressUp()
    {
        if (onPressUp != null)
            onPressUp();
    }
}
