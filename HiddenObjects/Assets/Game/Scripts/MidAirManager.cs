using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pump.HiddenObjects
{
    public class MidAirManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> midAirObjects = new List<GameObject>();

        private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

        void Start()
        {
            for (var i = 0; i < 100; ++i)
            {
                this.CreateMidAirObject();
            }

            this.Invoke("Show", 3f);
        }

        private void CreateMidAirObject()
        {
            var midAirObj = Instantiate(this.midAirObjects[Random.Range(0, this.midAirObjects.Count)]);
            midAirObj.transform.SetParent(this.transform);
            midAirObj.transform.localScale = Vector3.one;
            midAirObj.transform.localPosition = new Vector3(Random.Range(-75, 75), Random.Range(-100, 100), Random.Range(75, 250));

            this.spriteRenderers.Add(midAirObj.GetComponentInChildren<SpriteRenderer>());
        }

        public void Show()
        {
            for (var i = 0; i < this.spriteRenderers.Count; ++i)
            {
                this.spriteRenderers[i].enabled = true;
            }
        }
    }
}
