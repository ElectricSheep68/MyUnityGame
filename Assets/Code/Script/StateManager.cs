using UnityEngine;
using Assets.Code.States;
using Assets.Code.Interfaces;
using Assets.code.AI.CharacterState;

public class StateManager : MonoBehaviour
{
	// 現在のゲームの状態を保持
	private IState activeState;
	[HideInInspector]
	public GameData gameData;
	// Singletons
	public static StateManager instance;
	
	void Awake()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else { 
			DestroyImmediate (gameObject);                
		}
	}
	
	void OnGUI()
	{
		activeState.Render();
	}
	
	void Start()
	{
		activeState = new StartScene(this);
		gameData = GetComponent<GameData> ();
	}
	void Update()
	{
		if(activeState != null)
			activeState.StateUpdate();
	}
	public void SwitchState(IState newState)
	{
		activeState = newState;
	}
}