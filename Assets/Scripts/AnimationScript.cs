using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {
	
	SpriteRenderer sr;
	private Sprite[] frames;
	private int fNum;
	private float timeCounter;
	public string animName;
	public float frameTime;
	public bool flipX;
	public bool flipY;
	
	void Awake()
	{
		loadFrames(animName);
	}
	
	void loadFrames(string s)
	{
		frames = Resources.LoadAll<Sprite>(s);
	}
	
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		fNum = 0;
		timeCounter = 0f;
		flipX = false;
		flipY = false;
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		if(timeCounter >= frameTime)
		{
			timeCounter = 0f;
			fNum++;
			if(fNum >= frames.Length) fNum = 0;
		}
		
		transform.localScale = Vector3.one;
		
		if(flipX) transform.localScale += new Vector3(-2, 0, 0);
		if(flipY) transform.localScale += new Vector3(0, -2, 0);
		
		sr.sprite = frames[fNum];
	}
	
	public void ChangeAnim(string newAnim)
	{
		animName = newAnim;
		fNum = 0;
		timeCounter = 0;
		
		loadFrames(animName);
	}
}
