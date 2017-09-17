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
	public bool loop;
	
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
			if(fNum >= frames.Length)
			{
				if(loop) fNum = 0;
				else fNum = frames.Length - 1;
			}
		}
		
		transform.localScale = Vector3.one;
		
		if(flipX) transform.localScale += new Vector3(-2, 0, 0);
		if(flipY) transform.localScale += new Vector3(0, -2, 0);
		
		sr.sprite = frames[fNum];
	}
	
	public void ChangeAnim(string newAnim, bool loop)
	{
		if(animName == newAnim) return;
		
		animName = newAnim;
		fNum = 0;
		timeCounter = 0;
		this.loop = loop;
		
		loadFrames(animName);
	}
	
	public void ChangeAnim(string newAnim)
	{
		ChangeAnim(newAnim, true);
	}
}
