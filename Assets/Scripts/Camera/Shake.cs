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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            IncrementStressLevel();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            DecrementStressLevel();
        }
    }

    private void IncrementStressLevel()
    {
        moveCamera.m_Lens.OrthographicSize -= 0.06f;
        IncrementCameraShake(idleCameraNoise);
        IncrementCameraShake(moveCameraNoise);
        IncrementCameraShake(miniGameCameraNoise);
        IncrementCameraShake(dialogueCameraNoise);
    }

    private void DecrementStressLevel()
    {
        moveCamera.m_Lens.OrthographicSize += 0.06f;
        DecrementCameraShake(idleCameraNoise);
        DecrementCameraShake(moveCameraNoise);
        DecrementCameraShake(miniGameCameraNoise);
        DecrementCameraShake(dialogueCameraNoise);
    }

    private void IncrementCameraShake(CinemachineBasicMultiChannelPerlin cameraNoise)
    {
        cameraNoise.m_FrequencyGain *= 1.22f;
    }

    private void DecrementCameraShake(CinemachineBasicMultiChannelPerlin cameraNoise)
    {
        cameraNoise.m_FrequencyGain /= 1.22f;
    }

}
