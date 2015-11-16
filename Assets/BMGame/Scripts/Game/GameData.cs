using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class GameData{
	
	public bool isBeatTouch = false;

	public bool isGuild = true;//

	public enum GameState{start,stop,end}
	public GameState state;

	public bool isGameOver{
		get{
			return state ==GameState.end;
		}
	}

	public bool isGameStop{
		get{
			return state ==GameState.stop;
		}
	}



}
