using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/**
 * jski
 */
public class UIGame : MonoBehaviour {

	public UIAttackTip uiAttackTip;
	public UITopTip uiTopTip;
	public UITextTip uiTextTip;

	public Text bompTxt;
	public Image heroBlood;
	public Image enemyBlood;

	public Button reButton;
	public Button nextButton;
	public Button attackButton;

	public GameObject end;
	
	void Awake () {
		CenterInfo.uigame = this;
		ShowStart();
	}
	
	public void OnUpdate () {
		if (!CenterInfo.game.gameData.isGameStop) {
			if(CenterInfo.audioManager.isBeat){
				bompTxt.text = "YES";
			}else{
				bompTxt.text = "NO";
			}
		}

	}

	//------------------------tip---------------------------
	public void ShowAttackTip(){
		uiAttackTip.ShowTip ();
	}
	public void StopAttackTip(){
		uiAttackTip.StopTip ();
	}

	public void ShowTextTip(string tip){
		uiTextTip.ShowTip (tip);
	}
	public void StopTextTip(){
		uiTextTip.StopTip ();
	}
	
	public void ShowTopTip(){
		uiTopTip.ShowTip ();
	}
	public void StopTopTip(){
		uiTopTip.StopTip ();
	}
	//------------------------------------------------------

	public void HeroBlood(float f){
		heroBlood.fillAmount = f;
	}

	public void EnemyBlood(float f){
		enemyBlood.fillAmount = f;
	}

	public void OnAttackClick(){
		CenterInfo.actorManager.OnHeroAttack();
	}

	public void OnNextClick(){
		showAttackButton();
		CenterInfo.actorManager.ResetShowEnemy();
	}

	public void OnReClick(){
		showAttackButton();
		Application.LoadLevel("BMStart");
	}

	public void ShowStart(){
		showAttackButton();
		end.SetActive(false);
		bompTxt.gameObject.SetActive(true);
	}

	public void ShowEnd(){
		showReButton();
		end.SetActive(true);
		bompTxt.gameObject.SetActive(false);
	}

	public void showReButton(){
		reButton.gameObject.SetActive(true);
		nextButton.gameObject.SetActive(false);
		attackButton.gameObject.SetActive(false);
	}

	public void showNextButton(){
		reButton.gameObject.SetActive(false);
		nextButton.gameObject.SetActive(true);
		attackButton.gameObject.SetActive(false);
	}

	public void showAttackButton(){
		reButton.gameObject.SetActive(false);
		nextButton.gameObject.SetActive(false);
		attackButton.gameObject.SetActive(true);
	}

	public FlyText ShowFlyText(string txt,Vector3 pos){
		GameObject go = AssetManager.CreateGameObject("HurtFly");
		go.transform.SetParent((RectTransform)transform);
		go.transform.localPosition = pos;
		go.transform.localScale = new Vector3(1,1,1);
		FlyText ft = go.GetComponent<FlyText>();
		ft.ShowText(txt);
		return ft;
	}
}







