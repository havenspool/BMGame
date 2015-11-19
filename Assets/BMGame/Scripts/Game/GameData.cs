using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class GameData{

	private string[] waveEnemy = {"SlimeS","SlimeM","SlimeL","SlimeL"};
	private int thisWave = 0;
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
			return state == GameState.stop;
		}
	}

	public string NextWaveName(){
		thisWave ++;
		if (thisWave < waveEnemy.Length) {
			return waveEnemy[thisWave];
		}
		return "";
	}

	public void Reset(){
		thisWave = 0;
		isBeatTouch = false;
	}
}
