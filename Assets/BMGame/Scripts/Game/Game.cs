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
		get{
			if(null == _gameData){
				_gameData = new GameData();
			}
			return _gameData;
		}
	}

	public MXML mxml{
		get{
			return gameData.mxml;
		}
	}

	void Awake(){
		CenterInfo.game = this;
	}
	
	void Start(){
		uiGame = CenterInfo.uigame;
		actorManager = CenterInfo.actorManager;
		GameReStart ();
	}

	void Update(){
		if (isGamePlay) {
			actorManager.OnFrame ();
		}
	}

	void FixedUpdate () {
		if (isGamePlay) {
			uiGame.OnUpdate ();
			actorManager.OnUpdate ();
		}
	}

	public void GameStart(){
		gameData.state = GameData.GameState.start;
		CenterInfo.audioManager.AudioPlay ();
	}

	public void GameReStart(){
		gameData.state = GameData.GameState.start;
		ResetAll ();
	}

	public void GameEnemyDead(){
		if (gameData.NextWaveName () != "") {
			gameData.state = GameData.GameState.stop;
			CenterInfo.uigame.showNextButton ();
			CenterInfo.audioManager.AudioStop ();
			CenterInfo.uigame.Clear ();
		} else {
			GameEnd();
		}
	}

	public void GameNextWave(){
		gameData.state = GameData.GameState.start;
		CenterInfo.actorManager.ResetShowEnemy();
		CenterInfo.audioManager.AudioRePlay ();
		CenterInfo.uigame.Clear ();
	}

	public void GameEnd(){
		gameData.state = GameData.GameState.end;
		CenterInfo.uigame.ShowEnd();
		CenterInfo.audioManager.AudioStop ();
	}
	
	public void GameStop(){
		gameData.state = GameData.GameState.stop;
		CenterInfo.audioManager.AudioStop ();
	}

	public void ResetAll(){
		CenterInfo.audioManager.AudioRePlay ();
		CenterInfo.actorManager.ResetAllActor();
		CenterInfo.uigame.Clear ();

	}

	public bool isGamePlay{
		get{
			return !gameData.isGameStop && !gameData.isGameOver;
		}
	}


}