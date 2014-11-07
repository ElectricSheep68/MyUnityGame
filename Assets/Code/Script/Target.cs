using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
	public Transform targetMarker;
	
	void Start ()
	{
	}
	
	void Update ()
	{
		int button = 0;
		
		if(Input.GetMouseButtonDown(button)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			Debug.Log(ray);
			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) 
			{
				Vector3 targetPosition = hitInfo.point;
				targetMarker.position = targetPosition;
			}
		}
	}
	
}