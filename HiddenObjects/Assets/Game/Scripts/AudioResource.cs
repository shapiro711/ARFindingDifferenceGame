using System.Collections.Generic;
using UnityEngine;
using Pump.Core;

namespace Pump.HiddenObjects
{
    public class BGMName : BGMEnum
    {
        public static readonly int MAX = 3;

        public BGMName(int id, string name) : base(id, name) {}
    }

    public class FXName : FXEnum
    {
        public FXName(int id, string name) : base(id, name) { }
    }

    [CreateAssetMenu(fileName = "AudioResource", menuName = "Pump/HiddenObjects/Audio", order = 1)]
    public class AudioResource : ScriptableObject
    {
        [Header("BGM", order = 1)]
        public List<AudioInfo> bgmClips;

        [Header("FX", order = 2)]
        public AudioInfo titleStart;
        public AudioInfo button;
        public AudioInfo toggle;
        public List<AudioInfo> tileCrash;
        public AudioInfo flagInstall;
        public AudioInfo flagRemove;
        public AudioInfo explosion;
        public AudioInfo clear;
        public AudioInfo fail;
    }
}