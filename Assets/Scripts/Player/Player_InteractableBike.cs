public class Player_InteractableBike : InteractableBike
{
    public override void Init(GameManager _gameManager)
    {
        base.Init(_gameManager);
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Indicate_RagdollFalling()
    {
        base.Indicate_RagdollFalling();
    }

    public override void LandOnGround()
    {
        float targetLanding_X = transform.localEulerAngles.x;
  
        if (IsFalling()){
            if (!gameManager.IsWin && !gameManager.IsFail)
                gameManager.FailGame();

            Indicate_RagdollFalling();
        }
        IndicateGroundMove(targetLanding_X);
    }

    public override void Finish()
    {
        isFinished = true;
        if (!gameManager.IsFail)
            gameManager.WonGame();

        FinishLine();
    }

    protected override void FinishLine()
    {
        base.FinishLine();
    }

    protected override void IndicateGroundMove(float landingX)
    {
        base.IndicateGroundMove(landingX);
    }
}
