using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
/**
 * jski
 */
public class UMovie : MonoBehaviour
{
	public enum LoopType{clamp,loop,pingpong}
	public LoopType pType;
	public string movieName;
	public List<Sprite> lSprites;
	public float fSep = 0.05f;

	private bool isStop = false;
	
	public float showerWidth{
		get{
			if (shower == null){
				return 0;
			}
			return shower.rectTransform.rect.width;
		}
	}
	public float showerHeight
	{
		get{
			if (shower == null){
				return 0;
			}
			return shower.rectTransform.rect.height;
		}
	}
	
	void Awake(){
		shower = GetComponent<Image>();
		if (string.IsNullOrEmpty(movieName)){
			movieName = "movieName";
		}
	}
	
	void Start(){
		FrameShow(curFrame);
	}

	public void GotoAndStop(int iFrame){
		isStop = true;
		FrameShow(iFrame);
	}

	private bool isGoStop = false;
	private int stopFrame =0;
	public void GotoAndPlay(int iFrame){
		stopFrame = iFrame;
		if(stopFrame>=FrameCount){
			stopFrame = FrameCount;
		}else if(stopFrame<=0){
			stopFrame = 0;
		}
		isGoStop = true;
		isStop = false;
	}
		
	public void Play(int iFrame){
		isStop = false;
		isGoStop = false;
		stopFrame = 0;
		FrameShow(iFrame);
	}

	private void FrameShow(int iFrame){
		if(isGoStop && iFrame == stopFrame){
			isGoStop = false;
			isStop = true;
		}else{
			if (iFrame >= FrameCount){
				if(pType == LoopType.loop){
					iFrame = 0;
				}else{
					iFrame = FrameCount;
				}
			}
		}
		
		shower.sprite = lSprites[iFrame];
		curFrame = iFrame;
		shower.SetNativeSize();
		if (dMovieEvents.ContainsKey(iFrame))
		{
			foreach (delegateMovieEvent del in dMovieEvents[iFrame])
			{
				del();
			}
		}
	}

	private Image shower;
	private bool isPing = false;
	
	int curFrame = 0;
	public int FrameCount
	{
		get{
			return lSprites.Count-1;
		}
	}
	
	float fDelta = 0;
	void Update(){
		if(!isStop){
			fDelta += Time.deltaTime;
			if (fDelta > fSep)
			{
				fDelta = 0;
				if(pType == LoopType.loop){
					curFrame++;
				}else if(pType == LoopType.clamp){
					if (curFrame >= FrameCount){
						curFrame = FrameCount;
					}else{
						curFrame ++;
					}
				}else if(pType == LoopType.pingpong){
					if (curFrame >= FrameCount){
						isPing = true;
					}
					if (curFrame <= 0){
						isPing = false;
					}
					if(isPing){
						curFrame--;
					}else{
						curFrame++;
					}
				}
				FrameShow(curFrame);
			}
		}

	}
	
	public delegate void delegateMovieEvent();
	private Dictionary<int, List<delegateMovieEvent>> dMovieEvents = new Dictionary<int, List<delegateMovieEvent>>();
	public void RegistMovieEvent(int frame, delegateMovieEvent delEvent)
	{
		if (!dMovieEvents.ContainsKey(frame))
		{
			dMovieEvents.Add(frame, new List<delegateMovieEvent>());
		}
		dMovieEvents[frame].Add(delEvent);
	}
	public void UnregistMovieEvent(int frame, delegateMovieEvent delEvent)
	{
		if (!dMovieEvents.ContainsKey(frame))
		{
			return;
		}
		if (dMovieEvents[frame].Contains(delEvent))
		{
			dMovieEvents[frame].Remove(delEvent);
		}
	}
}