using UnityEngine;
using System.Collections;
namespace Assets.Code.Script{
public class Destroy : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		Destroy(other.gameObject);
	}
}
}