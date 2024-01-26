using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class SkinManager : MonoBehaviour
    {
        public  static SkinManager Instance;

        public SkinData[] skins;

        [CanBeNull]
        public SkinData GetRandomSkin()
        {
            if (skins.Length > 0)
            {
                // Select a random skin
                return skins[Random.Range(0, skins.Length)];
            }
            else
            {
                Debug.LogError("No skins available. Please assign skins in the Inspector.");
                return null;
            }
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
        }

    }
}
