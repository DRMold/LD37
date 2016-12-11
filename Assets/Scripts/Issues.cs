using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Issues : MonoBehaviour 
{
	Dictionary<string, Choices> issues = new Dictionary<string, Choices>();
	public GameObject go;
	public TextMesh txt;
	public MeshRenderer me;

	void Start()
	{
		issues.Add ("Issue 1", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 2", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 3", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 4", new Choices ("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 5", new Choices("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 6", new Choices("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 7", new Choices("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 8", new Choices("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 9", new Choices("Choice 1", "Result 1", "Choice 2", "Result 2"));
		issues.Add ("Issue 10", new Choices("Choice 1", "Result 1", "Choice 2", "Result 2"));

		me = go.GetComponent<MeshRenderer> ();
//		go = GameObject.FindGameObjectWithTag ("Issues");
//		txt = go.GetComponent<TextMesh> ();
	}

	public void RandomIssue()
	{
		txt.text = issues.ElementAt(Random.Range (0, issues.Count-1)).Key;
	}

	public void ChangeVisibility(bool visibility)
	{
		me.enabled = visibility;
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