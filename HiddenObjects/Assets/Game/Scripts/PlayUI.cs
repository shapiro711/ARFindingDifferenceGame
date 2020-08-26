using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pump.Core;

namespace Pump.HiddenObjects
{
    public class PlayUI : Core.MonoSingleton<PlayUI>, IListener
    {
        [SerializeField] private Text Correct_Text;
        [SerializeField] private Image Heart1;
        [SerializeField] private Image Heart2;
        [SerializeField] private Image Heart3;
        [SerializeField] private Slider Timebar;
        [SerializeField] private Button Settingbtn;
        [SerializeField] private Camera cam;

        public bool isClear = false;



        private List<int> ScoreList = new List<int>();
        private int BestScore = 100000;

        private UIControl uiControl;
        private GameManager gameManager;
       


        private GameObject target;


        public int Correct_Answer
        {
            get { return _correct_answer; }

            set
            {
                _correct_answer = Mathf.Clamp(value, 0, 3);

                if (_correct_answer >= 3 )
                {
                    EventManager.Instance.PostNotification(EVENT_TYPE.CLEAR, this, isClear);
                    return;
                }

                EventManager.Instance.PostNotification(EVENT_TYPE.CORRECT_ANSWER_CHANGE, this, _correct_answer);
            }
        }

        public float Timer
        {
            get { return _timer; }
            set
            {
                _timer = Mathf.Clamp(value, 0, 100);
                if (_timer <= 0)
                {
                    EventManager.Instance.PostNotification(EVENT_TYPE.DEAD, this, isClear);
                    return;
                }

                EventManager.Instance.PostNotification(EVENT_TYPE.TIME_CHANGE, this, _timer);
            }
        }

        public int Score
        {
            get { return _score; }
            set
            {

            }
        }


        public int Health
        {
            get { return _health; }
            set
            {
                _health = Mathf.Clamp(value, 0, 3);

                if (_health <= 0)
                {
                    EventManager.Instance.PostNotification(EVENT_TYPE.DEAD, this, isClear);
                    return;
                }
                EventManager.Instance.PostNotification(EVENT_TYPE.HEALTH_CHANGE, this, _health);
            }
        }


        private float _timer = 100.0f;
        private int _health = 3;
        private int _correct_answer = 0;
        private int _score = 0;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                DestroyImmediate(this);
        }



        private void Start()
        {
             EventManager.Instance.AddListener(EVENT_TYPE.CLEAR, this);
             EventManager.Instance.AddListener(EVENT_TYPE.DEAD, this);
             EventManager.Instance.AddListener(EVENT_TYPE.TIME_CHANGE, this);
             EventManager.Instance.AddListener(EVENT_TYPE.HEALTH_CHANGE, this);
             EventManager.Instance.AddListener(EVENT_TYPE.CORRECT_ANSWER_CHANGE, this);


        }


        void Update()

        {
            if (Timebar.value > 0.0f)
            {
                Timebar.value = Timer;
                Timer -= Time.deltaTime * 100;
                //Timer += Time.deltaTime*100;
            }

            Score += (int)Time.deltaTime;
            



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
                                Correct_Answer += 1;
                            }
                            else
                                if (Health > 0)
                                Health -= 1;
                        }
                    }
                }
            }




            Correct_Text.text = "정답 개수 : " + _correct_answer.ToString();

            if (Health == 3)
            {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(true);
            }
            else if (Health == 2)
            {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(true);
                Heart3.gameObject.SetActive(false);

            }
            else if (Health == 1)
            {
                Heart1.gameObject.SetActive(true);
                Heart2.gameObject.SetActive(false);
                Heart3.gameObject.SetActive(false);

            }



        }

        public void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null)
        {
            //Detect event type
            switch (Event_Type)
            {
                case EVENT_TYPE.CLEAR:
                    OnClear(Sender, (bool)Param);
                    break;

                case EVENT_TYPE.DEAD:
                    OnDead(Sender, (bool)Param);
                    break;

                case EVENT_TYPE.HEALTH_CHANGE:
                    OnHealthChange(Sender, (int)Param);
                    break;


                case EVENT_TYPE.TIME_CHANGE:
                    OnTimeChange(Sender, (float)Param);
                    break;

                case EVENT_TYPE.CORRECT_ANSWER_CHANGE:
                    OnCorrectChange(Sender, (int)Param);
                    break;
            }
        }

        void OnClear(Component PlayUI, bool isClear)
        {

            GameManager.instance.State = GameManager.GameState.Result;
            isClear = true;
            isBestTime();
            ScoreList.Add(Score);
            ES3.Save("Scroe", ScoreList);       
            ES3.Save("BestScore", BestScore);
        }

        void OnDead(Component PlayUI, bool isClear)
        {

            GameManager.instance.State = GameManager.GameState.Result;
            isClear = false;
            Debug.Log("죽었습니다");
            Debug.Log(GameManager.instance.State);
            ScoreList.Add(Score);
            ES3.Save("Scroe", ScoreList);
            ES3.Save("BestScore", BestScore);
        }

        void OnCorrectChange(Component PlayUI, int NewHealth)
        {

        }

        void OnTimeChange(Component PlayUI, float NewTime)
        {
            Debug.Log("Time Change" + NewTime.ToString());
        }

        void OnHealthChange(Component PlayUI, int NewHealth)
        {

        }

        void isBestTime()
        {
            for (int i = 0; i < ScoreList.Count; i++)
            {
                if (ScoreList[i] < BestScore)
                    ScoreList[i] = BestScore;
            }
        }

        public void OnClickSetting()
        {
            Time.timeScale = 0f;
            GameManager.instance.State = GameManager.GameState.Setting;
        }
    }
}
