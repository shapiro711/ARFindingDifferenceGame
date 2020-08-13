using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour

{

    [SerializeField] private Text text;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int TextResult;
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject Target_obj1;
    [SerializeField] private GameObject Target_obj2;
    [SerializeField] private GameObject Target_obj3;
    [SerializeField] private GameObject Plane_Finder;

    [SerializeField] private GameObject Cube_obj;
    List<GameObject> CubeList = new List<GameObject>();

    private BoxCollider BoxCol;
    private Vector3 pos;







    public void Input()
    {
        TextResult = int.Parse(inputField.text);

        for (int i = 0; i < TextResult; i++)


         {
             Vector3 pos = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(2.0f, 2.5f), Random.Range(-1.0f, 1.0f));
             Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
             GameObject _obj = Instantiate(prefab, pos, Quaternion.identity, GameObject.Find("Anchor_Plane").transform);
             _obj.GetComponent<MeshRenderer>().material.color = color;
             BoxCol=_obj.GetComponent<BoxCollider>();
             BoxCol.enabled = true;


             CubeList.Add(_obj);
            Plane_Finder.gameObject.SetActive(false);
     
         }
         CubeList[10].gameObject.layer = LayerMask.NameToLayer("Target");
         CubeList[11].gameObject.layer = LayerMask.NameToLayer("Target");
         CubeList[12].gameObject.layer = LayerMask.NameToLayer("Target");
         CubeList[10].gameObject.tag = "Target";
         CubeList[11].gameObject.tag = "Target";
         CubeList[12].gameObject.tag = "Target";
    }


    private void Update()
    {
 
        Target_obj1.transform.position = CubeList[10].transform.position;
        Target_obj2.transform.position = CubeList[11].transform.position;
        Target_obj3.transform.position = CubeList[12].transform.position;

    }




}


