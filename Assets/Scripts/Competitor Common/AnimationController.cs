using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private OnPathBehaviour onPathBehaviour;
    [SerializeField] private InteractableBike interactableBike;

    [SerializeField] private Transform body;
    [SerializeField] private float bodyStuntY;
    private float bodyOriginY;

    private Animator animator;

    private void OnEnable()
    {
        onPathBehaviour.onIndicateFlight += SetStunt;
        interactableBike.onIndicate_RagdollFalling += CloseAnimator;
        interactableBike.onIndicateGroundMove += SetRide;
    }

    private void OnDisable()
    {
        onPathBehaviour.onIndicateFlight -= SetStunt;
        interactableBike.onIndicate_RagdollFalling -= CloseAnimator;
        interactableBike.onIndicateGroundMove -= SetRide;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        bodyOriginY = body.localPosition.y;
    }

    private void SetRide(float refFloat)
    {
        animator.SetTrigger("Idle");
        StartCoroutine(BodyMove(.25f, bodyOriginY));
    }

    private void SetStunt(float refFloat)
    {
        int randMove = Random.Range(0, 3);
        if (randMove == 0)
        {
            animator.SetTrigger("Stunt1");
            StartCoroutine(BodyMove(.25f,bodyStuntY));
        }
        else if(randMove==1)
            animator.SetTrigger("Stunt2");
        else
            animator.SetTrigger("Stunt3");

    }

    private IEnumerator BodyMove(float completeInSeconds,float targetY)
    {
        float startBodyY = body.localPosition.y;
        float bodyLocalY = startBodyY;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / completeInSeconds;
            bodyLocalY = Mathf.Lerp(startBodyY, targetY, t);
            body.localPosition = new Vector3(body.localPosition.x, bodyLocalY, body.localPosition.z);
            yield return null;
        }
        yield break;
    }

    private void CloseAnimator()
    {
        animator.enabled = false;
    }
}
