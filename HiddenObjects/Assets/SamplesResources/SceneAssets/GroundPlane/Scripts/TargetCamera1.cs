using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera1 : MonoBehaviour
{
    public Transform target;


    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        tr.position = new Vector3(target.position.x , target.position.y+0.5f, target.position.z - 0.2f);

        tr.LookAt(target);
    }
}
