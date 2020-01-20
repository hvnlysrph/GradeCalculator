using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GradeCalculator : MonoBehaviour
{
	public GameObject scores;
	public InputField n1Grade;
	public InputField n2Grade;

	public bool findFirstSelectable = false;

	public Text aTest;
	public Text bTest;
	public Text cTest;
	public Text dTest;

	// Use this for initialization
	void Start ()
	{
		n1Grade.text = "Enter Grade";
		n2Grade.text = "EnterGrade";
		scores.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (EventSystem.current != null) {
				GameObject selected = EventSystem.current.currentSelectedGameObject;
				if (selected == null && findFirstSelectable) {
					Selectable found = (Selectable.allSelectables.Count > 0) ? Selectable.allSelectables [0] : null;
					if (found != null) {
						selected = found.gameObject;
					}
				}

				if (selected != null) {
					Selectable current = (Selectable)selected.GetComponent ("Selectable");

					if (current != null) {
						Selectable nextDown = current.FindSelectableOnDown ();
						Selectable nextUp = current.FindSelectableOnUp ();
						Selectable nextRight = current.FindSelectableOnRight ();
						Selectable nextLeft = current.FindSelectableOnLeft ();

						if (nextDown != null) {
							nextDown.Select ();
						} else if (nextUp != null) {
							nextUp.Select ();
						} else if (nextRight != null) {
							nextRight.Select ();
						} else if (nextLeft != null) {
							nextLeft.Select ();
						}
					}
				}
			}
		}
	}

	public void CalculateGrade ()
	{
		float n1 = float.Parse (n1Grade.text);
		float n2 = float.Parse (n2Grade.text);
		float a;
		float b;
		float c;
		float d;


		a = Mathf.Ceil ((92.5f - 0.4f * n1 - 0.4f * n2) / .2f);
		b = Mathf.Ceil ((84.5f - 0.4f * n1 - 0.4f * n2) / .2f);
		c = Mathf.Ceil ((74.5f - 0.4f * n1 - 0.4f * n2) / .2f);
		d = Mathf.Ceil ((69.5f - 0.4f * n1 - 0.4f * n2) / .2f);

		scores.SetActive (true);


		if (a > 100) {
			
			aTest.text = "Not Achievable";
		} else {
			if (a < 0)
				aTest.text = "0%";
			else
				aTest.text = a.ToString () + "%";
		}

		if (b > 100) {
			
			bTest.text = "Not Achievable";
		} else {
			if (b < 0)
				bTest.text = "0%";
			else
				bTest.text = b.ToString () + "%";
		}

		if (c > 100) {
			
			cTest.text = "Not Achievable";
		} else {
			if (c < 0) {
				if (b < 0) {
					cTest.text = "Not Achievable";
				} else
					cTest.text = "0%";
			} else
				cTest.text = c.ToString () + "%";
		}
		if (d > 100) {
			dTest.text = "Not Achievable";
		} else {
			if (d < 0) {
				if (c < 0) {
					dTest.text = "Not Achievable";
				} else
					dTest.text = "0%";
			} else
				dTest.text = d.ToString () + "%";
		}
	}
}
