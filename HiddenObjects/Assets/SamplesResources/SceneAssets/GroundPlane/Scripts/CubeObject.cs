using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObject: MonoBehaviour
{
    [SerializeField] private GameObject Cube_obj;
    List<GameObject> CubeList = new List<GameObject>();
    [SerializeField] private GameObject prefab;


    public Vector3 center;
    

    

    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i<100; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-0.02f, 0.02f)*i, Random.Range(1.0f, 1.25f)*i, Random.Range(-0.02f, 0.02f)*i);
            Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            GameObject _obj =Instantiate(prefab, pos, Quaternion.identity, GameObject.Find("Anchor_Plane").transform);
            _obj.GetComponent<MeshRenderer>().material.color = color;
            CubeList.Add(_obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
