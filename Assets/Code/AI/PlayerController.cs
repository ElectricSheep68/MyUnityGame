using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed = 10.0f;
	public float mass = 5.0f;
	public float force = 30.0f;
	public float minimumDistToAvoid = 1.0f;
	
	//Actual speed of the vehicle 
	private float curSpeed;
	private Vector3 targetPoint;
	
	// Use this for initialization
	void Start () 
	{
		mass = 5.0f;        
		targetPoint = Vector3.zero;
	}
	
	void OnGUI()
	{
		GUILayout.Label("操作対象の目標点をクリックしてください");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		RaycastHit hit;
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100.0f))
		{
			targetPoint = hit.point;
		}
		
		//目標点への方向ベクトル
		Vector3 dir = (targetPoint - transform.position);
		dir.Normalize();

		//目標点に到達後は停止
		if(Vector3.Distance(targetPoint, transform.position) < 3f)
			return;
		
		//速度をデルタタイムで標準化します。
		curSpeed = speed * Time.deltaTime;
		
		//操作対象の向きを変えます（回転）
		var rot = Quaternion.LookRotation(dir);
		transform.rotation = Quaternion.Slerp(transform.rotation, rot, 10.0f *  Time.deltaTime);
		
		//操作対象を動かします
		transform.position += transform.forward * curSpeed;
	}
	

	}
