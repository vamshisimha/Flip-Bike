using UnityEngine;

public class AI_SuspensionController : SuspensionController
{
    [SerializeField] private LandOnBehaviour landOnBehaviour;

    private void OnEnable()
    {
        GameManager.onStartGame += SetTorqueBehaviour;
        landOnBehaviour.onIndicateSpeedUpBehaviour += SetTorqueBehaviour;
    }

    private void OnDisable()
    {
        GameManager.onStartGame -= SetTorqueBehaviour;
        landOnBehaviour.onIndicateSpeedUpBehaviour -= SetTorqueBehaviour;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Action()
    {
        base.Action();
    }

    protected override void SetTorqueBehaviour()
    {
        base.SetTorqueBehaviour();
    }

    protected override void StopTorqueBehaviour()
    {
        base.StopTorqueBehaviour();
    }

    protected override void Indicate_StartSkid()
    {
        base.Indicate_StartSkid();
    }

    protected override void Indicate_EndSkid()
    {
        base.Indicate_EndSkid();
    }
}
