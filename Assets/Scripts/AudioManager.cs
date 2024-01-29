using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{

    [SerializeField] EventReference clubMusic;
    FMOD.Studio.EventInstance backgroundMusicInstance;

    void Start()
    {
        // Initialize and start the background music event
        backgroundMusicInstance = FMODUnity.RuntimeManager.CreateInstance(clubMusic);
        backgroundMusicInstance.start();
        backgroundMusicInstance.release(); // Release to allow it to play indefinitely

        UpdateFMODParameter("Stress", 1);
    }

    void UpdateFMODParameter(string paramName, float value)
    {
        // Update an FMOD parameter
        backgroundMusicInstance.setParameterByName(paramName, value);


    }
}
