//----------------------------------------------
// ProximityScaleExample
// Mark Hogan
// @markeahogan
// www.popupasylum.co.uk
//----------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// Proximity scale example.
/// This example uses delegates to respond to proximity sensor events
/// </summary>
public class ProximityScaleExample : MonoBehaviour {

	void Start() {
		//Add the method to the onProximityChange delegate,
		//Method must have the signaure void MethodName(PAProximity.Proximity arg)
		PAProximity.onProximityChange += SetScaleByProximity;
		 
		//Set start scale using PAProximity.proximity which hold the current proximity
		SetScaleByProximity(PAProximity.proximity);
	}

	void OnDestroy() {
		//When this object is destroyed (either by Destroy() or by loading a new level) the delegate MUST BE CLEANED UP!
		PAProximity.onProximityChange -= SetScaleByProximity;
	} 

	/// <summary>
	/// Sets the scale by proximity.
	/// Method is added to the onProximityChange delegate so must return void and have a PAProximity.Proximity parameter
	/// </summary>
	/// <param name="arg">Argument.</param>
	void SetScaleByProximity(PAProximity.Proximity arg) {
		transform.localScale *= ((arg == PAProximity.Proximity.NEAR)  ? 2f : 0.5f);
	} 
}
