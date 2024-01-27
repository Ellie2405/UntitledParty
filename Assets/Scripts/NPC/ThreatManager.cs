using UnityEngine;

public class ThreatManager : MonoBehaviour
{
    private float _threatLevel = 0f;

    public float IncreaseRate = 1f;
    public float IncreaseRateModifier = 1f;

    public float DecreaseRate = 0.5f;
    public float DecreaseRateModifier = 0.5f;

    public float MaxThreatLevel = 100f;

    public float UpdateThreatInterval = 10f;

    [SerializeField] CameraShakeManager cameraShakeManager;

    void Start()
    {
        InvokeRepeating("UpdateThreat", 0f, UpdateThreatInterval);
    }

    private void UpdateThreat()
    {
        IncreaseThreat(IncreaseRate); 
        IncreaseRate += IncreaseRateModifier;
        DecreaseRate += DecreaseRateModifier;
        Debug.Log($"UpdateThreat, threatLevel - {_threatLevel}, " +
                  $"increaseRate - {IncreaseRate}, " +
                  $"decreaseRate - {DecreaseRate}");

    }

    public void IncreaseThreat(float amount)
    {
        _threatLevel = Mathf.Min(MaxThreatLevel, _threatLevel + amount * IncreaseRate);
        cameraShakeManager.UpdateStressLevel((int)(_threatLevel / 10));
        Debug.Log($"Threat level increased to {_threatLevel}");

        if (_threatLevel >= MaxThreatLevel)
        {
            Debug.Log($"Game over!!");
        }
    }

    public void DecreaseThreat(float amount)
    {
        _threatLevel = Mathf.Max(0f, _threatLevel - amount / DecreaseRate);
        cameraShakeManager.UpdateStressLevel((int)(_threatLevel/ 10));
        Debug.Log($"Threat level decreased to {_threatLevel}");
    }

    public float GetThreatLevel()
    {
        return _threatLevel;
    }
}