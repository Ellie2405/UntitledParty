using System.Collections;
using UnityEngine;

public class ThreatManager : MonoBehaviour
{
    private float _threatLevel = 0f;

    public float IncreaseRate = 1f;
    public float IncreaseRateModifier = 0f;

    public float DecreaseRate = 0f;
    public float DecreaseRateModifier = 0f;

    public float MaxThreatLevel = 100f;

    public float UpdateThreatInterval = 10f;

    void Start()
    {
        StartCoroutine(UpdateThreat());
    }

    private IEnumerator UpdateThreat()
    {
        while (true)
        {
            Debug.Log("YAY");
            yield return new WaitForSeconds(UpdateThreatInterval);
            IncreaseThreat(IncreaseRate);
            IncreaseRate += IncreaseRateModifier;
            DecreaseRate += DecreaseRateModifier;
            Debug.Log($"UpdateThreat, threatLevel - {_threatLevel}, " +
                      $"increaseRate - {IncreaseRate}, " +
                      $"decreaseRate - {DecreaseRate}");

        }
    }

    public void IncreaseThreat(float amount)
    {
        _threatLevel = Mathf.Min(MaxThreatLevel, _threatLevel + amount * IncreaseRate);
        Debug.Log($"Threat level increased to {_threatLevel}");

        if (_threatLevel >= MaxThreatLevel)
        {
            Debug.Log($"Game over!!");
        }
    }

    public void DecreaseThreat(float amount)
    {
        _threatLevel = Mathf.Max(0f, _threatLevel - amount / DecreaseRate);
        Debug.Log($"Threat level decreased to {_threatLevel}");
    }

    public float GetThreatLevel()
    {
        return _threatLevel;
    }
}