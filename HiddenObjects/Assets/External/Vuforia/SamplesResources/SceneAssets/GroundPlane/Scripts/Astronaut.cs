using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Astronaut : MonoBehaviour

{
    [SerializeField] private Text text;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int TextResult;
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject Target_obj1;
    [SerializeField] private GameObject Target_obj2;
    [SerializeField] private GameObject Target_obj3;

    [SerializeField] private GameObject Cube_obj;
    List<GameObject> CubeList = new List<GameObject>();

    private BoxCollider BoxCol;
    private Vector3 pos;



    private void Start()
    {
        for (int i = 0; i < 100; i++)


        {
            Vector3 pos = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(2.0f, 2.5f), Random.Range(-1.0f, 1.0f));
            Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            GameObject _obj = Instantiate(prefab, pos, Quaternion.identity, GameObject.Find("Anchor_Plane").transform);
            _obj.GetComponent<MeshRenderer>().material.color = color;
            BoxCol = _obj.GetComponent<BoxCollider>();
            BoxCol.enabled = true;


            CubeList.Add(_obj);

        }
        CubeList[1].gameObject.layer = LayerMask.NameToLayer("Target");
        CubeList[2].gameObject.layer = LayerMask.NameToLayer("Target");
        CubeList[3].gameObject.layer = LayerMask.NameToLayer("Target");

    }




    public void Input()
    {
        TextResult = int.Parse(inputField.text);

        /*Target_obj1.SetActive(true);
        Target_obj1.transform.position = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(-1.0f, 1.0f));
        BoxCol=Target_obj1.GetComponent<BoxCollider>();
        BoxCol.enabled = true;
        //Target_obj2.SetActive(true);
        Target_obj2.transform.position = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(-1.0f, 1.0f));
        BoxCol = Target_obj2.GetComponent<BoxCollider>();
        BoxCol.enabled = true;
        //Target_obj3.SetActive(true);
        Target_obj3.transform.position = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(-1.0f, 1.0f));
        BoxCol = Target_obj3.GetComponent<BoxCollider>();
        BoxCol.enabled = true;*/

       /* for (int i = 0; i < TextResult; i++)


        {
            Vector3 pos = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(2.0f, 2.5f), Random.Range(-1.0f, 1.0f));
            Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            GameObject _obj = Instantiate(prefab, pos, Quaternion.identity, GameObject.Find("Anchor_Plane").transform);
            _obj.GetComponent<MeshRenderer>().material.color = color;
            BoxCol=_obj.GetComponent<BoxCollider>();
            BoxCol.enabled = true;

        
            CubeList.Add(_obj);
           
        }
        CubeList[1].gameObject.layer = LayerMask.NameToLayer("Target");
        CubeList[2].gameObject.layer = LayerMask.NameToLayer("Target");
        CubeList[3].gameObject.layer = LayerMask.NameToLayer("Target");*/
    }

    private void Update()
    {

        Target_obj1.transform.position = CubeList[1].transform.position;
        Target_obj2.transform.position = CubeList[2].transform.position;
        Target_obj3.transform.position = CubeList[3].transform.position;

       //pos = this.gameObject.transform.position;
       //text.text = "x :" + pos.x.ToString() + "y :" + pos.y.ToString() + "z :" + pos.z.ToString();
    }




}
