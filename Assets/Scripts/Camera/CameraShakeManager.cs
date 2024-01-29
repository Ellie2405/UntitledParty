using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShakeManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera idleCamera;
    [SerializeField] CinemachineVirtualCamera moveCamera;
    [SerializeField] CinemachineVirtualCamera miniGameCamera;
    [SerializeField] CinemachineVirtualCamera dialogueCamera;
    [SerializeField] int baseFrequency;

    private CinemachineBasicMultiChannelPerlin idleCameraNoise;
    private CinemachineBasicMultiChannelPerlin moveCameraNoise;
    private CinemachineBasicMultiChannelPerlin miniGameCameraNoise;
    private CinemachineBasicMultiChannelPerlin dialogueCameraNoise;

    private void Start()
    {
         idleCameraNoise = idleCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
         moveCameraNoise = moveCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
         miniGameCameraNoise = miniGameCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
         dialogueCameraNoise = dialogueCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void UpdateStressLevel(int level)
    {
        moveCamera.m_Lens.OrthographicSize += 0.06f;
        SetCameraShake(idleCameraNoise, level);
        SetCameraShake(moveCameraNoise, level);
        SetCameraShake(miniGameCameraNoise, level);
        SetCameraShake(dialogueCameraNoise, level);
    }

    private void SetCameraShake(CinemachineBasicMultiChannelPerlin cameraNoise, int level)
    {
        if (level <= 3) return;
        cameraNoise.m_FrequencyGain = baseFrequency + level;
    }

}
