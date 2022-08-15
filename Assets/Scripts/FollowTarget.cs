using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private void LateUpdate()     
    {
        Follow();
    }

    private void Follow()
    {
        transform.position = target.position + offset;
    }
}
