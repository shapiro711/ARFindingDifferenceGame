using UnityEngine;
using System.Collections;
//---------------------
public class ManualMouse : MonoBehaviour
{
	//---------------------
	//Get collider attached to this object
	private Collider Col = null;
	//---------------------
	//Awake function - called at start up
	void Awake()
	{
		//Get collider
		Col = GetComponent<Collider>();
	}
	//---------------------
	//Start Coroutine
	void Start()
	{
		StartCoroutine(UpdateMouse());
        Debug.Log("Enter");
    }
	//---------------------
	public IEnumerator UpdateMouse()
	{
		//Are we being intersected
		bool bIntersected = false;

		//Is button down or up
		bool bButtonDown = false;

		//Loop forever
		while(true)
		{
			//Get mouse screen position in terms of X and Y
			//You may need to use a different camera, if you have multiple
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			//Test ray for collision against this collider
			if (Col.Raycast(ray, out hit, Mathf.Infinity))
			{
                //Object was intersected - if not previous intersecting, then send on enter message
                if (!bIntersected)
                {
                    Debug.Log("Enter");
                    SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
                }

				bIntersected = true;

				//Test for mouse events
				if(!bButtonDown && Input.GetMouseButton(0))
                {
                    bButtonDown = true; SendMessage("OnMouseDown", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Down");
                }
				if(bButtonDown && !Input.GetMouseButton(0))
                {
                    bButtonDown = false; SendMessage("OnMouseUp", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Up");
                }
			}
			else
			{
                //Was previously entered and now leaving
                if (bIntersected)
                {
                    SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Exit");
                }

				bIntersected = false;
				bButtonDown = false;
			}

			//Wait until next frame
			yield return null;
		}
	}
	//---------------------
}
//---------------------