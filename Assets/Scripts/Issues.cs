using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Issues : MonoBehaviour 
{
	Dictionary<string, Choices> issues = new Dictionary<string, Choices>();
	public TextMesh issueTxt;
	public MeshRenderer issueMe;

	public TextMesh choice1Txt;
	public MeshRenderer choice1Me;

	public TextMesh choice2Txt;
	public MeshRenderer choice2Me;

	void Start()
	{
		InitializeIssues ();
	}

	public void RandomIssue()
	{
		string key = issues.ElementAt (Random.Range (0, issues.Count - 1)).Key;
		issueTxt.text = key;
		choice1Txt.text = issues [key].option1.response;
		choice2Txt.text = issues [key].option2.response;

	}

	public void ChangeVisibility(bool visibility)
	{
		issueMe.enabled = visibility;
		choice1Me.enabled = visibility;
		choice2Me.enabled = visibility;
	}

	private void InitializeIssues() 
	{
		issues.Add ("Issue 1", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 2", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 3", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 4", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 5", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 6", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 7", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 8", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 9", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 10", new Choices("Choice 1", "Result 1", "Choice 2", "Result 2"));
	}
}

public class CauseAndEffect
{
	public string response { get; set; }
	public string consequence { get; set; }

	public CauseAndEffect(string resp, string consq)
	{
		response = resp;
		consequence = consq;
	}
}

public class Choices
{
	public CauseAndEffect option1 { get; set; }
	public CauseAndEffect option2 { get; set; }

	public Choices(string resp1, string consq1, string resp2, string consq2) 
	{
		option1 = new CauseAndEffect (resp1, consq1);
		option2 = new CauseAndEffect (resp2, consq2);
	}
}