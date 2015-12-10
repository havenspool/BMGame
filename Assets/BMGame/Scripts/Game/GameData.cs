using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class GameData{

	private string[] waveEnemy = {"SlimeS","SlimeS","SlimeS"};//,"SlimeM","SlimeS","SlimeL"
	
	public float searchTime = 0;
	public float readyTime = 0;
	public bool isBeatTouch = false;
	public bool isGuild = true;
	
	public enum GameState{start,ready,fight,stop,end}
	public GameState state;
	
	private int thisWave = -1;
	public string thisWaveName{
		get{
			if(thisWave<waveEnemy.Length){
				return waveEnemy[thisWave];
			}
			return "";
		}
	}

	private MXML m;
	public MXML mxml{
		get{
			if(null == m){
				m = new MXML();
			}
			return m;
		}
	}

	public bool isGameReady{
		get{
			return state ==GameState.ready;
		}
	}

	public bool isGameStart{
		get{
			return state ==GameState.start;
		}
	}

	public bool isGameFight{
		get{
			return state ==GameState.fight;
		}
	}

	public bool isGameOver{
		get{
			return state ==GameState.end;
		}
	}

	public bool isGameStop{
		get{
			return state == GameState.stop;
		}
	}

	public string NextWave(){
		thisWave ++;
		if (waveEnemy.Length > 0) {
			if (thisWave < waveEnemy.Length) {
				return waveEnemy [thisWave];
			} else {
				thisWave = waveEnemy.Length - 1;
			}
		} else {
			thisWave = 0;
		}

		return "";
	}

	public bool isEndWave{
		get{
			if (thisWave < waveEnemy.Length-1) {
				return false;
			}
			return true;
		}
	}

	public void ResetAll(){
		thisWave = 0;
		ResetStart ();
	}

	public void ResetStart(){
		searchTime = 0;
		isBeatTouch = false;
	}


}
