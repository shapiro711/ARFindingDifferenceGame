using System.Collections.Generic;
using UnityEngine;

namespace Pump.Core
{
    public abstract class AudioManager : MonoBehaviour
    {
        private Transform myTransform;
        private AudioSource bgmAudioSource;
        protected List<AudioSource> fxAudioSources = new List<AudioSource>();

        [SerializeField] private bool active;

        protected AudioSource BGMAudioSource 
        {
            get => this.bgmAudioSource;
        }

        protected void Awake()
        {
            DontDestroyOnLoad(this.gameObject);

            this.myTransform = this.transform;
            this.bgmAudioSource = this.GetComponent<AudioSource>();
        }

        private void Update()
        {
            for (var i = 0; i < this.fxAudioSources.Count; ++i)
            {
                if (this.fxAudioSources[i].isPlaying == false)
                {
                    var deleteFx = this.fxAudioSources[i];
                    this.fxAudioSources.Remove(deleteFx);
                    Destroy(deleteFx.gameObject);
                }
            }
        }

        public void SetActive(bool value)
        {
            this.active = value;

            this.StopBGM();
            this.StopFX();
        }

        public void StopBGM()
        {
            this.bgmAudioSource.Stop();
            this.bgmAudioSource.enabled = false;
        }

        public void StopFX()
        {
            for (var i = 0; i < this.fxAudioSources.Count; ++i)
            {
                var deleteFx = this.fxAudioSources[i];
               this.fxAudioSources.Remove(deleteFx);
                Destroy(deleteFx.gameObject);
            }
        }

        public abstract void PlayBGM(BGMEnum bgmBame);
        protected void PlayBGM()
        {
            if (!this.active || this.bgmAudioSource.clip == null)
            {
                return;
            }

            this.bgmAudioSource.enabled = true;
            this.bgmAudioSource.loop = true;
            this.bgmAudioSource.playOnAwake = false;
            this.bgmAudioSource.Play();
        }

        public abstract void PlayFX(FXEnum fxName);

        protected GameObject CreateFXObject()
        {
            if (!this.active)
            {
                return null;
            }

            var fxObject = new GameObject();
            fxObject.transform.SetParent(this.myTransform);
            fxObject.transform.localPosition = Vector3.zero;
            var audioSource = fxObject.AddComponent<AudioSource>();
            audioSource.loop = false;
            audioSource.playOnAwake = false;

            return fxObject;
        }

        protected void PlayFX(GameObject fxGameObject, string fxName, AudioInfo fxClipInfo)
        {
            var fxAudioSource = fxGameObject.GetComponent<AudioSource>();
            fxAudioSource.gameObject.name = fxName;
            fxAudioSource.clip = fxClipInfo.clip;
            fxAudioSource.volume = fxClipInfo.volume;
            this.fxAudioSources.Add(fxAudioSource);

            fxAudioSource.Play();
        }
    }
}
