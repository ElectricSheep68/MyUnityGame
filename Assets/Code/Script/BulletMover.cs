﻿using UnityEngine;
using System.Collections;
namespace Saiyaku{
public class BulletMover : MonoBehaviour {
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(Vector3.forward*0.1f,Space.Self);
	}
}
}