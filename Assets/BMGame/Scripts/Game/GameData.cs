using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class GameData{
	
	public bool isBeatTouch = false;

	public enum GameState{start,stop,end}
	public GameState state;
//	public int state;//0 null  1 start -1 end

	public bool isGameOver{
		get{
			return state ==GameState.end;
		}
	}
}
