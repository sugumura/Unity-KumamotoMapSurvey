using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kender.uGUI;

public class SurveyUISystem : MonoBehaviour {	
	
	[SerializeField]
	private GameObject firstPanel;
	
	[SerializeField]
	private GameObject secondPanel;

	[SerializeField]
	private GameObject alertPanel;


	// first panel input
	[SerializeField]
	private InputField handleName;

	[SerializeField]
	private ComboBox old;

	[SerializeField]
	private ComboBox sex;

	[SerializeField]
	private ComboBox work;

	[SerializeField]
	private ComboBox location;

	[SerializeField]
	private ComboBox transfer;

	[SerializeField]
	private ComboBox count;


	// second panel input
	[SerializeField]
	private InputField comment;

	[SerializeField]
	private ComboBox kind;



	void Start() {
		Debug.Log("Start");
		ShowFirstPanel();
	}


	void ShowFirstPanel() {
		firstPanel.SetActive(true);
		secondPanel.SetActive(false);
		alertPanel.SetActive(false);
	}
	
	void ShowSecondPanel() {
		firstPanel.SetActive(false);
		secondPanel.SetActive(true);
		alertPanel.SetActive(false);
	}

	void ShowAlert() {
		alertPanel.SetActive(true);
	}

	void HideAlert() {
		alertPanel.SetActive(false);
	}


	bool CheckFirst() {
		if (handleName.text.Length == 0) {
			return false;
		}

		if (old.SelectedIndex == 0) {
			return false;
		}

		if (sex.SelectedIndex == 0) {
			return false;
		}

		if (work.SelectedIndex == 0) {
			return false;
		}

		if (location.SelectedIndex == 0) {
			return false;
		}

		if (transfer.SelectedIndex == 0) {
			return false;
		}

		if (count.SelectedIndex == 0) {
			return false;
		}
		return true;
	}

	bool CheckSecond() {
		if (comment.text.Length == 0) {
			return false;
		}
		
		if (kind.SelectedIndex == 0) {
			return false;
		}

		return true;
	}

	
	public void Next() {
		Debug.Log("Next");

		if (CheckFirst() == true) {
			ShowSecondPanel();
		} else {
			ShowAlert();
		}
	}
	
	public void Back() {
		Debug.Log("Back");
		ShowFirstPanel();
	}
	
	public void Complete() {
		Debug.Log("Complete");

		if (CheckSecond() == true) {
			Debug.Log ("Req");
		} else {
			ShowAlert();
		}
		
	}

	public void Close() {
		HideAlert();
	}
}
