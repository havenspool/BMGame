using UnityEngine;
using System.Collections;

public class Debugger : MonoBehaviour{
	
	void Awake () {
		text = this.GetComponent<GUIText>();
	}
	
	void Update () {
	}
	
	private static int traceLineCount = 0;
	private static GUIText text;
	
	public static void trace(string str){
		//DoTrace(str);
	}	

	
	public static void Note(string str){
		//DoTrace(str);
	}
	
	public static void Error(string str){
		//DoTrace("Error :: " + str);
	}
	
	private static void DoTrace(string str){
		if(null == text){
			Debug.Log(str);
			return;
		}
		traceLineCount++;
		string newText = text.text + "\n" + str;
		if(traceLineCount > 40){
			newText = newText.Substring(newText.IndexOf("\n")+1);
		}
		text.text = newText;
	}
	
	private static void AppendTrace(string str){
		if(null == text){
			Debug.Log(str);
			return;
		}
		string newText = text.text + str;
		text.text = newText;
	}
	
	private static void AppendTraceLine(string str){
		if(null == text){
			Debug.Log(str);
			return;
		}
		traceLineCount++;
		string newText = text.text + "\n" + str;
		if(traceLineCount > 30){
			newText = newText.Substring(newText.IndexOf("\n")+1);
		}
		text.text = newText;
	}
	
	
	
	public static void clear(){
		text.text = "cleared\n";
		traceLineCount = 1;
	}
}