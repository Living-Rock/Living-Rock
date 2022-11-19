using System;
using UnityEngine;

public class DistanceController : MonoBehaviour
{
    [SerializeField] private Transform crystal;
    [SerializeField] private float dieDistance = 15f;
    [SerializeField] private float recallPlateDieDistanceScale = 2f;
    [SerializeField] private Light light;
    [SerializeField] private float[] visionLossSteps = { 5f, 10f, 15f };
    [SerializeField] private float[] visionLossScales = { 1f, .5f, .33f };

    [HideInInspector] public bool isOnRecallPlate = false;

    private float _lightRange;

    private void Start()
    {
        _lightRange = light.range;
    }

    private void Update()
    {
        float distance = Mathf.Abs(Vector2.Distance(transform.position, crystal.position));
        float scale = isOnRecallPlate ? recallPlateDieDistanceScale : 1f;
        
        Debug.Log(distance+" "+ (dieDistance * scale));
        
        if(distance > dieDistance * scale)
            RespawnManager.Instance.RespawnPlayer();

        for (int i = 0; i < visionLossSteps.Length; i++)
        {
            if (distance < visionLossSteps[i])
            {
                light.range = _lightRange * visionLossScales[i];
                break;
            }
        }
    }
}