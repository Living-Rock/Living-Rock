using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DistanceController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform crystal;
    [SerializeField] private float dieDistance = 15f;
    [SerializeField] private float recallPlateDieDistanceScale = 2f;
    [SerializeField] private Light2D playerLight;
    [SerializeField] private float[] visionLossSteps = { 5f, 10f, 15f };
    [SerializeField] private float[] visionLossRangeScales = { 1f, .5f, .33f };
    [SerializeField] private float visionTransitionSpeed = 1f;
    [SerializeField] private Color initColor;
    [SerializeField] private Color dangerColor;

    [SerializeField] private bool _isOnRecallPlate = false;
    [SerializeField] private Vector2 _teleportPos = Vector2.zero;
    [SerializeField] private Image dangerRedVeil;
    [SerializeField] private Image dangerBlackVeil;

    [SerializeField] private float shakeTimer;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeAmount;
    
    private Camera _camera;
    private Vector3 startPos;

    public bool isOnRecallPlate
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

    public void SetTeleportPosX(float x)
    {
        _teleportPos = new Vector2(x, _teleportPos.y);
    }
    public void SetTeleportPosY(float y)
    {
        _teleportPos = new Vector2(_teleportPos.x, y);
    }

    [SerializeField] private LineRenderer lifeline;

    private float _originalRange;
    private int _lastStep = 0;

    private void Awake()
    {
        _originalRange = playerLight.shapeLightFalloffSize;
        lifeline.positionCount = 2;

        playerInput.actions["Teleportation"].performed += _ => TryTeleport();
        _camera = Camera.main;
    }

    private void Start()
    {
    }

    private void Update()
    {
        lifeline.SetPosition(0, transform.position);
        lifeline.SetPosition(1, crystal.position);
        float distance = Mathf.Abs(Vector2.Distance(transform.position, crystal.position));
        float scale = _isOnRecallPlate ? recallPlateDieDistanceScale : 1f;

        Color color = Color.Lerp(initColor, dangerColor, distance / (dieDistance * scale));
        color.a = 1f;

        float dangerDistance = 0.5f * dieDistance * scale;
        Color tmp = dangerRedVeil.color;
        Color tmp_2 = dangerBlackVeil.color;
        if (distance >= dangerDistance)
        {
            float t = (1/(dieDistance * scale - dangerDistance)) * distance - 1 * dangerDistance / (dieDistance * scale - dangerDistance);
            tmp.a = t*0.5f;
            tmp_2.a = t;
            dangerRedVeil.color = tmp;
            dangerBlackVeil.color = tmp_2;
        }

        lifeline.startColor = color;
        lifeline.endColor = color;
        
        if(distance > dieDistance * scale)
            RespawnManager.Instance.RespawnPlayer();

        for (int i = 0; i < visionLossSteps.Length; i++)
        {
            if (distance <= visionLossSteps[i])
            {
                if (_lastStep != i)
                    StartCoroutine(TransitionCo(_originalRange * visionLossRangeScales[i], _lastStep > i));
                
                _lastStep = i;
                break;
            }
        }
    }

    private IEnumerator TransitionCo(float targetRange, bool ascending)
    {
        float step = Mathf.Abs(targetRange - playerLight.shapeLightFalloffSize) / visionTransitionSpeed;
        
        if (ascending)
        {
            while (targetRange - playerLight.shapeLightFalloffSize >= 0)
            {
                playerLight.shapeLightFalloffSize += step * Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            while (targetRange - playerLight.shapeLightFalloffSize <= 0)
            {
                playerLight.shapeLightFalloffSize -= step * Time.deltaTime;
                yield return null;
            }
        }
        
        playerLight.shapeLightFalloffSize = targetRange;
        yield return null;
    }

    private void TryTeleport()
    {
        if (!_isOnRecallPlate) return;

        transform.position = _teleportPos;
    }

    
}