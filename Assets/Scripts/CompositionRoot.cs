using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private Player_FlightController playerFlightController;
    private InteractableBike[] interactableBikes;

    private GameManager gameManager;
    private InputInfo inputInfo;

    private void Awake()
    {
        inputInfo = FindObjectOfType<InputInfo>();
        gameManager = FindObjectOfType<GameManager>();
        interactableBikes = FindObjectsOfType<InteractableBike>();

        playerFlightController.Init(inputInfo);
        foreach(var current in interactableBikes)
        {
            current.Init(gameManager);
        }
    }
}
