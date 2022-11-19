using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DistanceController : MonoBehaviour
{
    [SerializeField] private Transform crystal;
    [SerializeField] private float dieDistance = 15f;
    [SerializeField] private float recallPlateDieDistanceScale = 2f;
    [SerializeField] private Light2D playerLight;
    [SerializeField] private float[] visionLossSteps = { 5f, 10f, 15f };
    [SerializeField] private float[] visionLossRangeScales = { 1f, .5f, .33f };

    [HideInInspector] public bool isOnRecallPlate = false;

    [SerializeField] private LineRenderer lifeline;

    private float _originalRange;

    private void Awake()
    {
        _originalRange = playerLight.shapeLightFalloffSize;
        lifeline.positionCount = 2;
    }

    private void Update()
    {
        lifeline.SetPosition(0, transform.position);
        lifeline.SetPosition(1, crystal.position);
        float distance = Mathf.Abs(Vector2.Distance(transform.position, crystal.position));
        float scale = isOnRecallPlate ? recallPlateDieDistanceScale : 1f;
        
        if(distance > dieDistance * scale)
            RespawnManager.Instance.RespawnPlayer();

        for (int i = 0; i < visionLossSteps.Length; i++)
        {
            if (distance < visionLossSteps[i])
            {
                playerLight.shapeLightFalloffSize = _originalRange * visionLossRangeScales[i];
                break;
            }
        }
    }
}