using UnityEngine;
using System.Collections.Generic;
namespace Saiyaku{
public class GameData : MonoBehaviour {
	
	public Texture2D beginTexture;
	
	public List<GameObject> cameras;
	
	private int initPlayerHP = 100;
	private int beginScore;
	
	[HideInInspector]
	public int playerHP;
	[HideInInspector]
	public int score;
	
	void Start() {
		playerHP = initPlayerHP;
	}
	
	void Reset() {
		playerHP = initPlayerHP;
		score = beginScore;
	}
	
	public void SetPlayerHP(int hp) 
	{
		initPlayerHP = hp;
		playerHP = hp;
	}
	
	public void SetScore()
	{
		beginScore = score;
	}
}
	}