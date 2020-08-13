using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject Sphere_obj;
    List<GameObject> SphereList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-0.2f, 1.0f), Random.Range(-1.0f, 1.0f));
            Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            GameObject _obj = Instantiate(prefab, pos, Quaternion.identity, GameObject.Find("Anchor_MidAir").transform);
            _obj.GetComponent<Renderer>().material.color = color;
            SphereList.Add(_obj);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
