using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmbienceTransitions
{

    [RequireComponent(typeof(AudioSource))]

    public class AmbienceManager : MonoBehaviour
    {
        [System.Serializable]
        public struct AmbienceSettings
        {
            public float lowFrequencyCutoff;
            public float volume;
            public AudioReverbPreset reverbPreset;
        }

        public AmbienceSettings startSettings;
        public AmbienceSettings currentSettings;
        public AmbienceSettings targetSettings;

        public float damping;

        public AudioLowPassFilter lowPassFilter;
        public AudioReverbFilter reverbFilter;
        public AudioSource source;
        public AudioClip[] ambiences;

        // Use this for initialization
        void Start()
        {
            source = GetComponent<AudioSource>();
            currentSettings = startSettings;
            targetSettings = startSettings;
            source.clip = ambiences[0];
            source.Play();

        }

        // Update is called once per frame
        void Update()
        {
            UpdateAmbience();
            ApplyAmbience();
        }

        private void UpdateAmbience()
        {
            currentSettings.lowFrequencyCutoff = Mathf.Lerp(currentSettings.lowFrequencyCutoff, targetSettings.lowFrequencyCutoff, Time.deltaTime * damping);
            currentSettings.reverbPreset = targetSettings.reverbPreset;
            currentSettings.volume = Mathf.Lerp(currentSettings.volume, targetSettings.volume, Time.deltaTime * damping);

        }

        private void ApplyAmbience()
        {
            if(lowPassFilter != null)
            {
                lowPassFilter.cutoffFrequency = currentSettings.lowFrequencyCutoff;
            }
            if(reverbFilter != null)
            {
                reverbFilter.reverbPreset = currentSettings.reverbPreset;
            }
            source.volume = currentSettings.volume;
        }

        public void RevertToStart()
        {
            targetSettings = startSettings;
        }
    }
}
