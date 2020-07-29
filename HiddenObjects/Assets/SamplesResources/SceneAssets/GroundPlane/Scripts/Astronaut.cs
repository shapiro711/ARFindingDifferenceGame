using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Astronaut : MonoBehaviour

{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int TextResult;
    [SerializeField] private InputField inputField;





    public void Input()
    {
        TextResult = int.Parse(inputField.text);

        for (int i = 0; i < TextResult; i++)
        {
            if (i % 2 == 1)
                Instantiate(prefab, new Vector3(transform.position.x + 0.05f * i, transform.position.y, transform.position.z), Quaternion.identity, GameObject.Find("Anchor_Plane").transform);
            else
                Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f * i), Quaternion.identity, GameObject.Find("Anchor_Plane").transform);

        }
    }


}
