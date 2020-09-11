using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Config the eventID, invoke the In_Raise() function (using UnityEvent or something) to raise event
/// </summary>
public class RaiseEventHelper : MonoBehaviour {
	[SerializeField] EventID eventID;

	public void In_Raise() {
		this.PostEvent(eventID);
	}
}
