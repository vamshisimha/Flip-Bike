using UnityEngine;
using System.Collections;
using System;

public class SuspensionController : MonoBehaviour
{
    [SerializeField] protected Transform body;
    protected Quaternion bodyRot;
    protected float suspension_AngleX;

    protected bool isTorque;

    public event Action onIndicate_StartSkid;
    public event Action onIndicate_EndSkid; 

    protected virtual void Start()
    {
        bodyRot = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    protected virtual void Update()
    {
        Action();
    }

    protected virtual void Action()
    {
        if (!isTorque)
            suspension_AngleX = Mathf.Lerp(suspension_AngleX, 0, Time.deltaTime);

        body.transform.localRotation = Quaternion.Lerp(body.transform.localRotation, bodyRot, Time.deltaTime);
        transform.localRotation = Quaternion.Euler(new Vector3(suspension_AngleX, 0, 0));
    }

    protected virtual void StopTorqueBehaviour()
    {
        isTorque = false;
        bodyRot = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    protected virtual void SetTorqueBehaviour()
    {
        isTorque = true;
        bodyRot = Quaternion.Euler(new Vector3(-13, 0, 0));
        StartCoroutine(TorqueBehaviour(.3f));
    }

    //Sinusodial Ease Out Function
    private IEnumerator TorqueBehaviour(float completeInSeconds) 
    {
        float startAngleX = transform.localEulerAngles.x;
        float diffAngleX = 12.5f - startAngleX;

        float t = 0f;
        while (t < completeInSeconds)
        {
            if (isTorque)
            {
                t += Time.deltaTime;
                suspension_AngleX = diffAngleX * Mathf.Sin(t / completeInSeconds * (Mathf.PI / 2f)) + startAngleX;
                Indicate_StartSkid();
            }
            else
            {
                StopTorqueBehaviour();
                Indicate_EndSkid();
                yield break;
            }
            yield return null;
        }
        StopTorqueBehaviour();
        Indicate_EndSkid();
        yield break;
    }

    protected virtual void Indicate_StartSkid()  
    {
        if (onIndicate_StartSkid != null)
            onIndicate_StartSkid();
    }

    protected virtual void Indicate_EndSkid()
    {
        if (onIndicate_EndSkid != null)
            onIndicate_EndSkid();
    }
}
