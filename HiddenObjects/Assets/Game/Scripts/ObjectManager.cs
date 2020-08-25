using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pump.HiddenObjects
{
    public class ObjectManager : Core.MonoSingleton<ObjectManager>
    {
        [SerializeField] private Transform anchorPlacementTransform;
        [SerializeField] private GameObject cubePrefab;

        private void Start()
        {
            this.SetupFloor();
        }

        private void SetupFloor()
        {
            GameObject floor = new GameObject("Floor", typeof(BoxCollider));
            floor.transform.SetParent(this.anchorPlacementTransform);
            floor.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            floor.transform.localScale = Vector3.one;
            floor.GetComponent<BoxCollider>().size = new Vector3(100f, 0, 100f);

            var cube = Instantiate(this.cubePrefab);

            cube.transform.SetParent(floor.transform);
            cube.transform.localPosition = Vector3.one;
            cube.transform.localRotation = Quaternion.identity;
        }

        private void Update()
        {
            UIControl.Instance.Log = this.anchorPlacementTransform.position.ToString();
        }
    }
}
