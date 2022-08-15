using UnityEngine;

public class Rear_TireController : TireController
{
    [SerializeField] private SuspensionController suspensionController;
    [SerializeField] private SpeedController speedController;

    Transform skidTrail;
    ParticleSystem skidSmoke;
    private bool isSkid;

    [SerializeField] private Transform skidTrailPrefab;
    [SerializeField] private ParticleSystem smokePrefab;
    [SerializeField] private Transform trailPlacer;
    [SerializeField] private Vector3 skidPos;

    private void OnEnable()
    {
        suspensionController.onIndicate_StartSkid += SetSkid;
        suspensionController.onIndicate_EndSkid += CloseSkid;
    }

    private void OnDisable()
    {
        suspensionController.onIndicate_StartSkid -= SetSkid;
        suspensionController.onIndicate_EndSkid -= CloseSkid;
    }

    private void Start()
    {
        skidSmoke = Instantiate(smokePrefab);
        skidSmoke.Stop();
    }

    protected override void Update()
    {
        base.Update();
        CheckForSkid();
    }

    private void CheckForSkid()
    {
        if (!speedController.IsFlight){
            if (isSkid){
                StartSkidTrails();
                skidSmoke.transform.position = skidTrail.position;
                skidSmoke.Emit(1);
            }
            else
                EndSkidTrail();
        }
        else
            EndSkidTrail();
    }

    private void StartSkidTrails()
    {
        if (skidTrail == null)
            skidTrail = Instantiate(skidTrailPrefab);

        skidTrail.forward = -trailPlacer.forward;
        skidTrail.parent = trailPlacer;
        skidTrail.localPosition = skidPos;
    }

    private void EndSkidTrail()
    {
        if (skidTrail == null) return;
        Transform holder = skidTrail;
        skidTrail = null;
        holder.parent = null;
        Destroy(holder.gameObject, 30);
    }

    private void SetSkid()
    {
        isSkid = true;
    }

    private void CloseSkid()
    {
        isSkid = false;
    }
}
