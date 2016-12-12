using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour 
{ 
	private int windowWidth = 250;
	private int windowHeight = 50;
	private int startingxDistance  = 20;
	private int startingYDistance  = 50;
	private int window_delta;

	public int   monthsInOffice   = 0;
	public int   twitterFollowers = 3000;
	public int budget           = 500000; // Currency

	public int civilTensionThreshold = 90;
	public int globalTensionThreshold = 90;

	public int currentCivilUnrest = 40;
	public int currentGlobalTension = 60;

	public Rect termLengthWindow;
	public Rect followerWindow;
	public Rect budgetWindow;
	public Rect civilUnrestWindow;
	public Rect globalTensionWindow;

	public Slider civilUnrest;
	public Slider globalTension;
	//These Sliders should be have y-coordinate of = startingYDistance + (window_delta * (order + 0.5))

	public Button tweetButton;

	private Dictionary<string, int> windowValues;

	void Start () 
	{
		window_delta = windowHeight + 10;

		termLengthWindow = new Rect(startingxDistance, startingYDistance + (window_delta * 1), windowWidth, windowHeight);
		followerWindow = new Rect(startingxDistance, startingYDistance + (window_delta * 2), windowWidth, windowHeight);
		budgetWindow = new Rect(startingxDistance, startingYDistance + (window_delta * 3), windowWidth, windowHeight);
		civilUnrestWindow = new Rect(startingxDistance, startingYDistance + (window_delta * 4), windowWidth, windowHeight);
		globalTensionWindow = new Rect(startingxDistance, startingYDistance + (window_delta * 5), windowWidth, windowHeight);

//		tweetButton.onClick.AddListener(ChangeTwitterFollowerAmt);

		windowValues = new Dictionary<string, int>(){
			{"Term", monthsInOffice},
			{"Twitter Followers", twitterFollowers},
			{"Budget", budget},
			{"Civil Unrest", currentCivilUnrest},
			{"Global Tension", currentGlobalTension}
		};

		Debug.Log ("Intensify");
		StartCoroutine (Intensify ());
	}

	void Update () 
	{
		;
	}

	void OnGUI() {
		termLengthWindow = GUI.Window(0, termLengthWindow, DoMyWindow, getWindowString("Term"));
		followerWindow = GUI.Window(1, followerWindow, ChangeTwitterFollowerAmt,getWindowString("Twitter Followers"));
		budgetWindow = GUI.Window(2, budgetWindow, DoMyWindow, getWindowString("Budget"));
		civilUnrestWindow = GUI.Window(3, civilUnrestWindow, DoMyWindow, getWindowString("Civil Unrest"));
		globalTensionWindow = GUI.Window(4, globalTensionWindow, DoMyWindow, getWindowString("Global Tension"));
	}

	#region Callback
	void DoMyWindow(int windowID) {
		;
	}

	void ChangeTwitterFollowerAmt(int windowID){
		if (GUI.Button (new Rect(startingxDistance, startingYDistance + (window_delta * 3 + 50), windowWidth, windowHeight/2), "Tweet")) {
			twitterFollowers += 10;
			windowValues ["Twitter Followers"] = twitterFollowers;
			print ("twitter followers:" + twitterFollowers);
		}
	}
	#endregion



	#region Helper Functions
	string getWindowString(string windowName){
		return windowName +  " : " + windowValues[windowName];
	}

	IEnumerator Intensify() {
		Debug.Log ("Intensify Init");
		while (currentCivilUnrest < civilTensionThreshold || currentGlobalTension < globalTensionThreshold) 
		{
			currentCivilUnrest++;
			civilUnrest.value = currentCivilUnrest;
			windowValues ["Civil Unrest"] = currentCivilUnrest;

			currentGlobalTension++;
			globalTension.value = currentGlobalTension;
			windowValues ["Global Tension"] = currentGlobalTension;

			yield return new WaitForSeconds (2f);
		}
	}
	#endregion
}
