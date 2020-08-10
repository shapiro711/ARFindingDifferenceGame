using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EVENT_TYPE
{
    GAME_END,
    HEALTH_CHANGE,
    DEAD,
    CORRECT_ANSWER_CHANGE
}

public interface IListener
{
    void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null);
}
