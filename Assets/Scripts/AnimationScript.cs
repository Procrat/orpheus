using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationScript : MonoBehaviour {
	
	SpriteRenderer sr;
	private Sprite[] frames;
	private int fNum;
	private float timeCounter;
	public string animName;
	public float frameTime;
	public bool flipX;
	public bool flipY;
	public bool loop;
	private bool finished;
	private Action<string> finishCallback;
	
	void Awake()
	{
		loadFrames(animName);
		sr = GetComponent<SpriteRenderer>();
		fNum = 0;
		timeCounter = 0f;
		flipX = false;
		flipY = false;
		loop = true;
		finished = false;
		finishCallback = null;
	}
	
	void loadFrames(string s)
	{
		frames = Resources.LoadAll<Sprite>(s);
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		if(timeCounter >= frameTime)
		{
			timeCounter = 0f;
			fNum++;
			if(fNum >= frames.Length)
			{
				if(loop) fNum = 0;
				else
				{
					fNum = frames.Length - 1;
					if(!finished)
					{
						finished = true;
						if(finishCallback != null) finishCallback(animName);
					}
				}
			}
		}
		var scale = transform.localScale;
		if(flipX != scale.x < 0) scale.x*= -1;
		if(flipY != scale.y < 0) scale.y*= -1;
		transform.localScale = scale;

		sr.sprite = frames[fNum];
	}
	
	public void ChangeAnim(string newAnim, bool loop)
	{
		if(animName == newAnim) return;
		
		animName = newAnim;
		fNum = 0;
		timeCounter = 0;
		this.loop = loop;
		finished = false;
		finishCallback = null;
		
		loadFrames(animName);
	}
	
	public void ChangeAnim(string newAnim)
	{
		ChangeAnim(newAnim, true);
	}
	
	public void ChangeAnim(string newAnim, bool loop, Action<string> callback)
	{
		ChangeAnim(newAnim, loop);
		finishCallback = callback;
	}
}
