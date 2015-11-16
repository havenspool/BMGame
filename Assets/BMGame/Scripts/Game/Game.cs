using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/**
 * jski
 */
public class Game : MonoBehaviour {

	private UIGame uiGame;
	private ActorManager actorManager;

	private GameData _gameData;
	public GameData gameData{
		get{return _gameData;}
	}

	void Awake(){
		CenterInfo.game = this;
		if(null == _gameData){
			_gameData = new GameData();
		}
	}
	
	void Start(){
		uiGame = CenterInfo.uigame;
		actorManager = CenterInfo.actorManager;
		GameReStart ();
	}

	void Update(){
		actorManager.OnFrame ();
	}

	void FixedUpdate () {
		if (!CenterInfo.game.gameData.isGameStop) {
			uiGame.OnUpdate ();
			actorManager.OnUpdate ();
		}
	}

	public void GameStart(){
		gameData.state = GameData.GameState.start;
	}

	public void GameReStart(){
		gameData.state = GameData.GameState.start;
		CenterInfo.actorManager.ResetAllActor();
	}

	public void GameEnd(){
		gameData.state = GameData.GameState.end;
		CenterInfo.uigame.ShowEnd();
	}

	public void GameNext(){
		gameData.state =  GameData.GameState.stop;
		CenterInfo.uigame.showNextButton();
	}

	public void GameStop(){
		gameData.state = GameData.GameState.stop;

	}



}