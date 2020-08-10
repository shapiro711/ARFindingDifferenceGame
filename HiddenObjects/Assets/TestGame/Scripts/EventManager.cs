using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    /* public static EventManager Instance
     {
         get { return Instance; }
         set { }
     }

     private static EventManager instance = null;

     private Dictionary<EVENT_TYPE, List<IListener>> Listeners =
         new Dictionary<EVENT_TYPE, List<IListener>>();

     // Start is called before the first frame update
     void Awake()
     {
         if (instance == null)
         {
             instance = this;
             DontDestroyOnLoad(gameObject);
         }
         else
             DestroyImmediate(this);
     }

     public void AddListener(EVENT_TYPE Event_Type, IListener Listener)
     {
         List<IListener> ListenList = null;

         //이벤트 형식 키 존재 검사 있으면 추가
         if(Listeners.TryGetValue(Event_Type, out ListenList))
         {
             ListenList.Add(Listener);
             return;
         }
     }

     public void PostNotification(EVENT_TYPE Event_Type, Component Sender, object Param = null)
     {
         List<IListener> ListenList = null;

         if (!Listeners.TryGetValue(Event_Type, out ListenList))
             return;

         for(int i =0; i<ListenList.Count; i++)
         {
             if (!ListenList[i].Equals(null))
                 ListenList[i].OnEvent(Event_Type, Sender, Param);
         }
     }

     //이벤트 종류 제거
     public void RemoveEvent(EVENT_TYPE Event_Type)
     {
         Listeners.Remove(Event_Type);
     }

     //딕셔너리에서 삭제
     public void RemoveRedundancies()
     {

     }

     private void OnLevelWasLoaded()
     {
         RemoveRedundancies();
     }
     */

    public static EventManager Instance
    {
        get { return instance; }
        set { }
    }

    private static EventManager instance = null;
    
    private Dictionary<EVENT_TYPE, List<IListener>> Listeners = new Dictionary<EVENT_TYPE, List<IListener>>();


    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
            DestroyImmediate(this);
    }

    public void AddListener(EVENT_TYPE Event_Type, IListener Listener)
    {
    
        List<IListener> ListenList = null;

        if (Listeners.TryGetValue(Event_Type, out ListenList))
        {
            ListenList.Add(Listener);
            return;
        }

        ListenList = new List<IListener>();
        ListenList.Add(Listener);
        Listeners.Add(Event_Type, ListenList);
    }

    public void PostNotification(EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {

        List<IListener> ListenList = null;

        if (!Listeners.TryGetValue(Event_Type, out ListenList))
            return;

        for (int i = 0; i < ListenList.Count; i++)
        {
            if (!ListenList[i].Equals(null))
                ListenList[i].OnEvent(Event_Type, Sender, Param);
        }
    }

    public void RemoveEvent(EVENT_TYPE Event_Type)
    {

        Listeners.Remove(Event_Type);
    }

    public void RemoveRedundancies()
    {

        Dictionary<EVENT_TYPE, List<IListener>> TmpListeners = new Dictionary<EVENT_TYPE, List<IListener>>();

        foreach (KeyValuePair<EVENT_TYPE, List<IListener>> Item in Listeners)
        {

            for (int i = Item.Value.Count - 1; i >= 0; i--)
            {
                if (Item.Value[i].Equals(null))
                    Item.Value.RemoveAt(i);
            }

            if (Item.Value.Count > 0)
                TmpListeners.Add(Item.Key, Item.Value);
        }

        Listeners = TmpListeners;
    }

    void OnLevelWasLoaded()
    {
        RemoveRedundancies();
    }

}
