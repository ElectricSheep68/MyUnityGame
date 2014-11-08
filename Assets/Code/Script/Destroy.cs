using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		Destroy(other.gameObject);
	}
}