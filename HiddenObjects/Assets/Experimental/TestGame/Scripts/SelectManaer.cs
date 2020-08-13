using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManaer : MonoBehaviour, IListener
{
    [SerializeField] private Text Correct_Text;
    [SerializeField] private Image Heart1;
    [SerializeField] private Image Heart2;
    [SerializeField] private Image Heart3;
    public Camera cam;

    private GameObject target;


    public int Correct_Answer
    {
        get{ return _correct_answer;} 

        set
        {
            _health = Mathf.Clamp(value, 0, 3);

            EventManager.Instance.PostNotification(EVENT_TYPE.CORRECT_ANSWER_CHANGE, this, _health);
        }
    }

    public int Health
    {
        get { return _health; }
        set
        {
            _health = Mathf.Clamp(value, 0, 3);
            EventManager.Instance.PostNotification(EVENT_TYPE.HEALTH_CHANGE, this, _health);
        }
    }

    private int _health = 3;
    private int _correct_answer = 0;


    private void Start()
    {
        EventManager.Instance.AddListener(EVENT_TYPE.HEALTH_CHANGE, this);
        EventManager.Instance.AddListener(EVENT_TYPE.CORRECT_ANSWER_CHANGE, this);
    }


    void Update()

    {
        /*if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();
            if (target.Equals(gameObject))
            {
                _correct_answer += 1;
                if (target.CompareTag("Target") == true)
                    _correct_answer += 1;
                else
                    if(_health>0)
                        _health -= 1;
            }
        }*/

        if (Input.touchCount != 0)

        {
            Vector2 pos = Input.GetTouch(0).position;
            Vector3 theTouch = new Vector3(pos.x, pos.y, 0.0f);
            Ray ray = cam.ScreenPointToRay(theTouch);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                if (Input.GetTouch(0).phase == TouchPhase.Began)  //처음 터치 시
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {

                        if (hit.collider.CompareTag("Target"))
                        {
                            _correct_answer += 1;
                        }
                        else
                            if (_health > 0)
                            _health -= 1;
                    }
                }
            }

            /*else if (Input.GetTouch(0).phase == TouchPhase.Moved) // 터치하고 움직일때

            {



            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended) // 터치 떼면

            {



            }*/

        }
    



        Correct_Text.text = "정답 개수 : " +_correct_answer.ToString();

        if (_health == 3)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(true);
            Heart3.gameObject.SetActive(true);
        }
        else if(_health == 2)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(true);
            Heart3.gameObject.SetActive(false);

        }
        else if (_health == 1)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(false);
            Heart3.gameObject.SetActive(false);

        }



    }



   /* private GameObject GetClickedObject()

    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            if (hit.collider.gameObject.CompareTag("Selectable")|| hit.collider.gameObject.CompareTag("Target"))
                 target = hit.collider.gameObject;
        }

        return target;

    }*/

    public void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {
        //Detect event type
        switch (Event_Type)
        {
            case EVENT_TYPE.HEALTH_CHANGE:
                OnHealthChange(Sender, (int)Param);
                break;
        }

        switch (Event_Type)
        {
            case EVENT_TYPE.CORRECT_ANSWER_CHANGE:
                OnHealthChange(Sender, (int)Param);
                break;
        }
    }

    void OnCorrectChange(Component SelectManaer, int NewHealth)
    {
        Debug.Log("correct");
    }

    void OnHealthChange(Component SelectManaer, int NewHealth)
    {
        Debug.Log("HealthChange");
    }

}
