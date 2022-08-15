public class Player_SuspensionController : SuspensionController
{
    private void OnEnable()
    {
        InputInfo.onPressDown += SetTorqueBehaviour;
        InputInfo.onPressUp += StopTorqueBehaviour;
    }

    private void OnDisable()
    {
        InputInfo.onPressDown -= SetTorqueBehaviour;
        InputInfo.onPressUp -= StopTorqueBehaviour;
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
