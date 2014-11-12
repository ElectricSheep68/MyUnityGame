using UnityEngine;
using System.Collections;
namespace Saiyaku{
public class Destroy : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		Destroy(other.gameObject);
	}
}
}