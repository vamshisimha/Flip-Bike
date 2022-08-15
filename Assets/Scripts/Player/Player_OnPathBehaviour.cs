public class Player_OnPathBehaviour : OnPathBehaviour
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void ControllingEnd_of_Path()
    {
        base.ControllingEnd_of_Path();
    }

    protected override void Enter_to_Path(float refX)
    {
        base.Enter_to_Path(refX);
    }

    protected override void Exit_from_Path()
    {
        base.Exit_from_Path();
    }

    protected override void SetTrack(int targetTrackIndex)
    {
        base.SetTrack(targetTrackIndex);
    }

    protected override void SetUsableRow()
    {
        base.SetUsableRow();
    }

    protected override void IndicateClosePhysics()
    {
        base.IndicateClosePhysics();
    }

    protected override void IndicateFlight(float targetFlightVelocity)
    {
        base.IndicateFlight(targetFlightVelocity);
    }
}
