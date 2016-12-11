using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{ 
	public int   monthsInOffice   = 0;
	public int   twitterFollowers = 3000;
	public int budget           = 500000; // Currency

	public int startingCivilUnrest     = 100; // Percent: 0-1
	public int currentCivilUnrest;

	public int startingGlobalTension    = 50; // Percent: 0-1
	public int currentGlobalTension;

	private Dictionary<string, int> windowValues;

	private int windowWidth = 250;
	private int windowHeight = 40;
	private int startingDistance = 50;
	private int window_delta = 50;

	public Rect termLengthWindow;
	public Rect followerWindow;
	public Rect budgetWindow;
	public Rect civilUnrestWindow;
	public Rect globalTensionWindow;

	public Slider civilUnrest;


	void Start () 
	{
		termLengthWindow = new Rect(20, startingDistance + (window_delta * 1), windowWidth, windowHeight);
		followerWindow = new Rect(20, startingDistance + (window_delta * 2), windowWidth, windowHeight);
		budgetWindow = new Rect(20, startingDistance + (window_delta * 3), windowWidth, windowHeight);
		civilUnrestWindow = new Rect(20, startingDistance + (window_delta * 4), windowWidth, windowHeight);
		globalTensionWindow = new Rect(20, startingDistance + (window_delta * 5), windowWidth, windowHeight);

		currentCivilUnrest = startingCivilUnrest;
		currentGlobalTension = startingGlobalTension;

		windowValues = new Dictionary<string, int>(){
			{"Term", monthsInOffice},
			{"Twitter Followers", twitterFollowers},
			{"Civil Unrest", currentCivilUnrest},
			{"Global Tension", currentGlobalTension},
			{"Budget", currentCivilUnrest}
		};
	}

	void Update () 
	{
		civilUnrest.value = Mathf.MoveTowards (civilUnrest.value, 10.0f, 10f * Time.deltaTime);
		windowValues ["Civil Unrest"] = currentCivilUnrest;
	}

	void OnGUI() {
		termLengthWindow = GUI.Window(0, termLengthWindow, DoMyWindow, getWindowString("Term"));
		followerWindow = GUI.Window(1, followerWindow, DoMyWindow,getWindowString("Twitter Followers"));
		budgetWindow = GUI.Window(2, budgetWindow, DoMyWindow, getWindowString("Budget"));
		civilUnrestWindow = GUI.Window(3, civilUnrestWindow, DoMyWindow, getWindowString("Civil Unrest"));
		globalTensionWindow = GUI.Window(4, globalTensionWindow, DoMyWindow, getWindowString("Global Tension"));
	}

	void DoMyWindow(int windowID) {
		;
	}

	string getWindowString(string windowName){
		return windowName +  " : " + windowValues[windowName];
	}
}
