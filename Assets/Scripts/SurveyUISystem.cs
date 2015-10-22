using UnityEngine;
using System.Collections;

public class SurveyUISystem : MonoBehaviour {
	
	[SerializeField]
	private GameObject firstPanel;
	
	[SerializeField]
	private GameObject secondPanel;
	
	void Start() {
		Debug.Log("Start");
		ShowFirstPanel();
	}
	
	void ShowFirstPanel() {
		firstPanel.SetActive(true);
		secondPanel.SetActive(false);
	}
	
	void ShowSecondPanel() {
		firstPanel.SetActive(false);
		secondPanel.SetActive(true);
	}
	
	public void Next() {
		Debug.Log("Next");
		ShowSecondPanel();
	}
	
	public void Back() {
		Debug.Log("Back");
		ShowFirstPanel();
	}
	
	public void Complete() {
		Debug.Log("Complete");
		
	}
}
