using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Pump.Core
{
    public class BGMEnum : Enumeration
    {
        public BGMEnum(int id, string name) : base(id, name) { }
    }

    public class FXEnum : Enumeration
    {
        public FXEnum(int id, string name) : base(id, name) { }
    }

    [Serializable]
    public class AudioInfo
    {
        public AudioClip clip;
        public float volume = 1.0f;
    }
}