using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterPhysicsController : MonoBehaviour
{
    private RigBuilder rigBuilder;
    private Rigidbody[] physicsBodies;

    [SerializeField] private InteractableBike interactableBike;

    private void OnEnable()
    {
        interactableBike.onIndicate_RagdollFalling += Fall;
    }

    private void OnDisable()
    {
        interactableBike.onIndicate_RagdollFalling -= Fall;
    }

    private void Awake()
    {
        physicsBodies = GetComponentsInChildren<Rigidbody>();
        rigBuilder = GetComponent<RigBuilder>();
    }

    private void Start()
    {
        ClosePhysicsBodies();
    }

    private void Fall()
    {
        Vector3 fallingPosition = transform.position;
        rigBuilder.enabled = false;
        transform.position = fallingPosition + new Vector3(0, 1, 0);
        transform.SetParent(null);
        OpenPhysicsBodies();
    }

    private void ClosePhysicsBodies()
    {
        foreach (var current in physicsBodies)
            current.isKinematic = true;
    }

    private void OpenPhysicsBodies()
    {
        foreach (var current in physicsBodies)
            current.isKinematic = false;
    }
}
