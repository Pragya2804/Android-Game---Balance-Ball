//----------------------------------------------
// ProximityColorExample
// Mark Hogan
// @markeahogan
// www.popupasylum.co.uk
//----------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// Proximity color example.
/// This example uses Unity messaging to react to proximity sensor events
/// </summary>
public class ProximityColorExample : MonoBehaviour {

	/// <summary>
	/// The color to apply when the proximity is NEAR
	/// </summary>
	public Color nearColor = Color.red;

	/// <summary>
	/// The color to apply whenthe proximity is FAR
	/// </summary>
	public Color farColor = Color.blue;

	void Start(){
		//By assigning this GameObject as the PAProximity messageReceiver it will receive "OnProximityChange" events
		PAProximity.messageReceiver = gameObject;

		//Set the color to the current proximity color using PAProximity.proximity
		OnProximityChange(PAProximity.proximity);
	}

	/// <summary>
	/// The proximity change event, called by unity's SendMessage function.
	/// The method must have a PAProximity.Proximity parameter
	/// </summary>
	/// <param name="proximity">Proximity.</param>
	void OnProximityChange(PAProximity.Proximity proximity) {
		GetComponent<Renderer>().material.color = ((proximity == PAProximity.Proximity.NEAR) ? nearColor : farColor);
	} 
}
