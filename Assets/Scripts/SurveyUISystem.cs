using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Kender.uGUI;
using Parse;

public class SurveyUISystem : MonoBehaviour {	
	
	[SerializeField]
	private GameObject firstPanel;
	
	[SerializeField]
	private GameObject secondPanel;

	[SerializeField]
	private GameObject alertPanel;

	[SerializeField]
	private GameObject errorPanel;


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
		errorPanel.SetActive(false);
	}
	
	void ShowSecondPanel() {
		firstPanel.SetActive(false);
		secondPanel.SetActive(true);
		alertPanel.SetActive(false);
		errorPanel.SetActive(false);
	}

	void ShowAlert() {
		alertPanel.SetActive(true);
	}

	void HideAlert() {
		alertPanel.SetActive(false);
	}

	void ShowErrorAlert() {
		errorPanel.SetActive(true);
	}

	void HideErrorAlert() {
		errorPanel.SetActive(false);
	}


	private bool CheckFirst() {
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

	private bool CheckSecond() {
		if (comment.text.Length == 0) {
			return false;
		}
		
		if (kind.SelectedIndex == 0) {
			return false;
		}

		return true;
	}

	// TODO: save virtual map location
	private void SaveParse() {
		Debug.Log("SaveParse");
		ParseObject survey = new ParseObject("Survey");
		survey["handleName"] = handleName.text;
		survey["old"]        = GetCaption(old);
		survey["sex"]        = GetCaption(sex);
		survey["work"]       = GetCaption(work);
		survey["location"]   = GetCaption(location);
		survey["transfer"]   = GetCaption(transfer);
		survey["count"]      = GetCaption(count);
		survey["comment"]    = comment.text;
		survey["kind"]       = GetCaption(kind);

		survey.SaveAsync ().ContinueWith(task =>  {
			
			if (CheckTask("Save", task)){			
				Debug.Log("ObjectId : " + survey.ObjectId);
			} else {
				// TODO: show alert call to main thread
			}
			
		});
		
	}

	// ref: https://gist.github.com/kankikuchi/d3b8e128ab8747c53430
	private bool CheckTask(string taskName, System.Threading.Tasks.Task task){
		if (task.IsCanceled)
		{
			Debug.Log(taskName + ": cancel");
		}
		else if (task.IsFaulted)
		{
			Debug.Log(taskName + ": fail");
			
			// error message
			using (IEnumerator<System.Exception> enumerator = task.Exception.InnerExceptions.GetEnumerator()) {
				if (enumerator.MoveNext()) {
					ParseException error = (ParseException) enumerator.Current;
					Debug.Log(error.Message);
				}
			}
		}
		else
		{
			Debug.Log(taskName + ": success");
			return true;
		}
		
		return false;
	}
	
	
	private string GetCaption (ComboBox box) {
		return box.Items[box.SelectedIndex].Caption;
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
			SaveParse();
		} else {
			ShowAlert();
		}
		
	}

	public void CloseAlert() {
		HideAlert();
	}

	public void CloseError() {
		HideErrorAlert();
	}
}
