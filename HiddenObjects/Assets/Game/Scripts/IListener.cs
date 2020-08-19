using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pump.HiddenObjects
{
    public enum EVENT_TYPE
    {
        GAME_END,
        HEALTH_CHANGE,
        DEAD,
        CORRECT_ANSWER_CHANGE,
        TIME_CHANGE,
        CLEAR
    }

    public interface IListener
    {
        void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null);
    }
}
