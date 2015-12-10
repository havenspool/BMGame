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
	}

	void Update(){
		actorManager.OnFrame ();
		if (gameData.isGameStart) {
			gameData.searchTime ++;
			if (gameData.searchTime > 0 * CenterInfo.frame) {
				GameNextEnemyShow ();
			}
		} else if (gameData.isGameReady) {
			gameData.readyTime ++;
			if(gameData.readyTime>0* CenterInfo.frame) {
				GameFight();
				CenterInfo.uigame.ShowBompTxt(false,"");
			}else{
				CenterInfo.uigame.ShowBompTxt(true,ReadyTime().ToString());
			}
		}
	}

	private float ReadyTime(){
		float f = Util.CF (4 - gameData.readyTime / CenterInfo.frame, 0);
		if (f > 3) {
			f = 3;
		} else if (f < 1) {
			f = 1;
		}
		return f;
	}

	void FixedUpdate () {
		if (gameData.isGameFight) {
			uiGame.OnUpdate ();
			actorManager.OnUpdate ();
		}
	}

//	public void GameReStart(){
//		gameData.state = GameData.GameState.start;
//		ResetAll ();
//	}

	public void GameNextEnemyShow(){
		gameData.state = GameData.GameState.ready;
		gameData.searchTime = 0;
		gameData.NextWave ();
		CenterInfo.actorManager.ResetShowEnemy();
	}

	public void GameFight(){
		gameData.state = GameData.GameState.fight;
		gameData.readyTime = 0;
		CenterInfo.audioManager.AudioRePlay ();
		CenterInfo.uigame.Clear ();
	}

	public void GameEnemyDead(){
		gameData.state = GameData.GameState.stop;
		if (!gameData.isEndWave) {
			CenterInfo.uigame.Clear ();
			StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
				gameData.state = GameData.GameState.start;
				CenterInfo.audioManager.AudioStop ();
			},3f));
		} else {
			GameEnd();
		}
	}

	public void GameEnd(){
		gameData.state = GameData.GameState.end;
		CenterInfo.uigame.Clear ();
		StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
			CenterInfo.uigame.ShowEnd();
			CenterInfo.audioManager.AudioStop ();
		},3f));
	}
	
//	public void GameStop(){
//		gameData.state = GameData.GameState.stop;
//		CenterInfo.audioManager.AudioStop ();
//	}

	public void ResetAll(){
		gameData.ResetAll ();
		CenterInfo.audioManager.AudioRePlay ();
		CenterInfo.actorManager.ResetShowHero ();
		CenterInfo.actorManager.ClearEnemy ();
		CenterInfo.uigame.Clear ();

	}

	public bool isGamePlay{
		get{
			return !gameData.isGameStop && !gameData.isGameOver;
		}
	}


}