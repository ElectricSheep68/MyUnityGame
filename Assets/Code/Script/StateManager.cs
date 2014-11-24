using UnityEngine;
using System.Collections;

namespace Saiyaku{
public class StateManager : MonoBehaviour,IStateManager
{
	private IState activeState;
	public StateManagerController statecontroller;
	[HideInInspector]
	public GameData gameData;
	public static StateManager instance;

	public void OnEnable(){
			statecontroller.SetStateManagerController(this);
	}

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
		Debug.Log("scene State " + activeState);
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
	public string FormatState(){
			return statecontroller.GetStateName();
		}
}
}