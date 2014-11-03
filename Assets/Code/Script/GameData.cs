using UnityEngine;
using System.Collections.Generic;
using Assets.Code.States;
using Assets.Code.Interfaces;

public class GameData : MonoBehaviour {
	
	public Texture2D beginTexture;
	public List<GameObject> cameras;
	private int beginScore;
	[HideInInspector]
	public int score;	
	public void SetScore()
	{
		beginScore = score;
	}
}