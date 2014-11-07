using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// @http://creativecommons.org/licenses/by-sa/3.0/

/// 本抽象クラスはFSMの状態を記述します。
/// 各状態はDictionary型にペア（transition-state）を持ちます。
/// ある状態のときに、遷移が発生するときに、どの状態に遷移すべきかを記述しています。
/// Reasonメソッド： どの遷移が実施されるか指定します。
/// Actメソッド:　現状態での処理を記述します。

public abstract class FSMState
{
	protected Dictionary<Transition, FSMStateID> map = new Dictionary<Transition, FSMStateID>();
	protected FSMStateID stateID;
	public FSMStateID ID { get { return stateID; } }
	protected Vector3 destPos;
	protected Transform[] waypoints;
	protected float curRotSpeed;
	protected float curSpeed;
	
	public void AddTransition(Transition transition, FSMStateID id)
	{
		// 引数の確認
		if (transition == Transition.None || id == FSMStateID.None)
		{
			Debug.LogWarning("FSMState : Null transition not allowed");
			return;
		}
		
		//現在の状態が、Map（Dictionary）に存在するか確認。
		if (map.ContainsKey(transition))
		{
			Debug.LogWarning("FSMState ERROR: transition is already inside the map");
			return;
		}
		
		map.Add(transition, id);
		Debug.Log("Added : " + transition + " with ID : " + id);
	}
	
	/// 不要な遷移をDictionaryから削除します。
	public void DeleteTransition(Transition trans)
	{
		// null遷移か確認
		if (trans == Transition.None)
		{
			Debug.LogError("FSMState ERROR: NullTransition is not allowed");
			return;
		}
		
		// ペアがmapにあるか判別
		if (map.ContainsKey(trans))
		{
			map.Remove(trans);
			return;
		}
		Debug.LogError("FSMState ERROR: 指定された遷移はリストにありません。");
	}
	
	
	/// この状態が遷移するときに、どの状態になるか判別します。
	public FSMStateID GetOutputState(Transition trans)
	{
		// 遷移がNullか確認
		if (trans == Transition.None)
		{
			Debug.LogError("FSMState ERROR: 不正なNull遷移です。");
			return FSMStateID.None;
		}
		
		// mapが遷移を持つか確認
		if (map.ContainsKey(trans))
		{
			return map[trans];
		}
		
		Debug.LogError("FSMState ERROR: " + trans+ " は存在しません。");
		return FSMStateID.None;
	}
	
	/// 状態が遷移すべきかの意思決定を行います。
	public abstract void Reason(Transform player, Transform npc);
	
	/// NPC(敵キャラ)の処理、行動、動作を指定します。
	public abstract void Act(Transform player, Transform npc);
	
	/// 次の策敵ポイントを指定します。乱数で動作します。
	public void FindNextPoint()
	{
		//Debug.Log("Finding next point");
		int rndIndex = Random.Range(0, waypoints.Length);
		Vector3 rndPosition = Vector3.zero;
		destPos = waypoints[rndIndex].position + rndPosition;
	}
	
	/// 次のポジションが、現在の位置と同じかチェックします。
	protected bool IsInCurrentRange(Transform trans, Vector3 pos)
	{
		float xPos = Mathf.Abs(pos.x - trans.position.x);
		float zPos = Mathf.Abs(pos.z - trans.position.z);
		
		if (xPos <= 50 && zPos <= 50)
			return true;
		
		return false;
	}
}