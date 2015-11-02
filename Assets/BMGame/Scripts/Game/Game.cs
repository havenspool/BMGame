using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/**
 * jski
 */
public class Game : MonoBehaviour {

	private GameData _gameData;
	public GameData gameData{
		get{
			if(null == _gameData){
				_gameData = new GameData();
			}
			return _gameData;
		}
	}

	void Awake(){
		CenterInfo.game = this;
	}

	void Start(){
		ShowGameStart();
	}

	public void ShowGameStart(){
		gameData.state = GameData.GameState.start;
		CenterInfo.actorManager.ResetAllActor();
	}

	public void ShowGameEnd(){
		gameData.state = GameData.GameState.end;
		CenterInfo.uigame.ShowEnd();
	}

	public void ShowGameNext(){
		gameData.state =  GameData.GameState.stop;
		CenterInfo.uigame.showNextButton();
	}



}