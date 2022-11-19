using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DistanceController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform crystal;
    [SerializeField] private float dieDistance = 15f;
    [SerializeField] private float recallPlateDieDistanceScale = 2f;
    [SerializeField] private Light light;
    [SerializeField] private float[] visionLossSteps = { 5f, 10f, 15f };
    [SerializeField] private float[] visionLossScales = { 1f, .5f, .33f };

    [SerializeField] private bool _isOnRecallPlate = false;
    
    [HideInInspector] public bool isOnRecallPlate
    {
        get
        {
            return _isOnRecallPlate;
        }

        set
        {
            _isOnRecallPlate = value;
        }
    }

    [SerializeField] private LineRenderer lifeline;

    private float _lightRange;

    private void Start()
    {
        _lightRange = light.range;
        lifeline.positionCount = 2;

        playerInput.actions["Teleportation"].performed += _ => TryTeleport();
    }

    private void Update()
    {
        lifeline.SetPosition(0, transform.position);
        lifeline.SetPosition(1, crystal.position);
        float distance = Mathf.Abs(Vector2.Distance(transform.position, crystal.position));
        float scale = _isOnRecallPlate ? recallPlateDieDistanceScale : 1f;
        
        //Debug.Log(distance+" "+ (dieDistance * scale));
        
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

    private void TryTeleport()
    {
        if (!_isOnRecallPlate) return;

        transform.position = crystal.position;
    }
}