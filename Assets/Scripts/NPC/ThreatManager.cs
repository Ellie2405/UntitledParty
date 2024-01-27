using UnityEngine;
using DG.Tweening;

public class ThreatManager : MonoBehaviour
{
    [SerializeField] Player player; 
    [SerializeField] GM gm; 
    private float _threatLevel = 0f;

    public float IncreaseRate = 1f;
    public float IncreaseRateModifier = 1f;

    public float DecreaseRate = 0.5f;
    public float DecreaseRateModifier = 0.5f;

    public float MaxThreatLevel = 100f;

    public float UpdateThreatInterval = 10f;

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
        Debug.Log($"Threat level increased to {_threatLevel}");

        if (_threatLevel >= MaxThreatLevel)
        {
            player.EndGameAct();
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