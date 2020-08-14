using UnityEngine;
using Pump.Core;

namespace Pump.HiddenObjects
{
    public class AudioManager : Core.AudioManager
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField] private AudioResource audioResource;

        private new void Awake()
        {
            Instance = this;

            base.Awake();
        }

        public override void PlayBGM(BGMEnum bgmName)
        {
            var name = bgmName as BGMName;
            var audioClip = this.audioResource.bgmClips[name.Id];

            this.BGMAudioSource.volume = audioClip.volume;
            this.BGMAudioSource.clip = audioClip.clip;
            
            base.PlayBGM();
        }

        public override void PlayFX(FXEnum fxName)
        {
            var fxGameObject = this.CreateFXObject();
            if (fxGameObject == null) {
                return;
            }

            var fxClip = fxName as FXName;
            AudioInfo fxClipInfo = null;
            

            if (fxClipInfo == null) return;

            //base.PlayFX(fxGameObject, fxClip.Name, fxClipInfo);
        }

        public void PlayTileCrashFx(int noCrashTiles)
        {
            var fxGameObject = this.CreateFXObject();
            if (fxGameObject == null)
            {
                return;
            }

            int crashIndex = 0;
            if (noCrashTiles >= 20 && noCrashTiles < 30)
            {
                crashIndex = 1;
            }
            else if (noCrashTiles >= 10 && noCrashTiles < 20)
            {
                crashIndex = 2;
            }
            else if (noCrashTiles >= 1 && noCrashTiles < 10)
            {
                crashIndex = Random.Range(3,5);
            }

            AudioInfo fxClipInfo = this.audioResource.tileCrash[crashIndex];
            base.PlayFX(fxGameObject, string.Format("TileCrash{0}", crashIndex), fxClipInfo);
        }
    }
}