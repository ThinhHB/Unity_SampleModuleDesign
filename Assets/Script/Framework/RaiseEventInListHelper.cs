using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Same to RaiseEventHelper, but now we got a list, and the func In_Raise(int) will have int parameter to select the event index
/// </summary>
public class RaiseEventInListHelper : MonoBehaviour {
	[SerializeField] EventID[] eventList;

	public void In_Raise(int index) {
		if(index < 0 || index >= eventList.Length) {
			Common.Warning(false, this, $"Raise event out of index [{index}]");
			return;
		}
		this.PostEvent(eventList[index]);
	}
}
