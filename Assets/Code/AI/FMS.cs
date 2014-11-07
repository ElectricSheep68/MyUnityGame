using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour 
{
	protected Transform playerTransform;
	
	//NPCの次の到達点
	protected Vector3 destPos;
	
	//策敵する地点のリスト
	protected GameObject[] pointList;
	
	//弾丸の射撃速度
	protected float shootRate;
	protected float elapsedTime;
	
	//砲台
	public Transform turret { get; set; }
	public Transform bulletSpawnPoint { get; set; }
	
	protected virtual void Initialize() { }
	protected virtual void FSMUpdate() { }
	protected virtual void FSMFixedUpdate() { }
	
	// Use this for initialization
	void Start () 
	{
		Initialize();
	}
	
	// Update is called once per frame
	void Update () 
	{
		FSMUpdate();
	}
	
	void FixedUpdate()
	{
		FSMFixedUpdate();
	}    
}
