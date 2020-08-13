using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OkButtion : MonoBehaviour
{
    [SerializeField] private int TextResult;
    [SerializeField] private InputField inputField;

    public void Input()
    {
        TextResult = int.Parse(inputField.text);

        GameObject prefab = Resources.Load("Cube") as GameObject;
        for (int i = 0; i < TextResult; i++)
        {
            GameObject go = Instantiate(prefab) as GameObject;
            go.transform.position = new Vector3(0, i * 5, 0);
        }
    }
}
