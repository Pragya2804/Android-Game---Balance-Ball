//----------------------------------------------
// PAProximity
// Mark Hogan
// @markeahogan
// www.popupasylum.co.uk
//----------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// PA proximity.
/// Extends Monobehaviour to recieve Android messages via UnitySendMessage
/// </summary>
public class PAProximity : MonoBehaviour {

	///Enum for proximity types
	public enum Proximity{
		FAR,
		NEAR
	}

	/// <summary>
	/// UnitySendMessage requires an instance in the scene to recieve messages
	/// </summary>
	private static PAProximity instance;

	/// <summary>
	/// The PAProximity java object that monitors the proximity sensor and dispatches messages
	/// </summary>
	private AndroidJavaObject paProximity = null;

	/// <summary>
	/// The current private proximity.
	/// </summary>
	private static Proximity _proximity = Proximity.FAR;

	/// <summary>
	/// The private delegate function
	/// </summary>
	private static ProximityDelegate _onProximityChange;

	/// <summary>
	/// The private _messageReciever.
	/// </summary>
	private static GameObject _messageReciever;

	/// <summary>
	/// Gets the current proximity.
	/// </summary>
	/// <value>The proximity.</value>
	public static Proximity proximity{
		get{
			//Create an instance if no instance exists
			if (!instance){CreateInstance();}
			return _proximity;
		}
		private set{
			_proximity = value;
		}
	}

	/// <summary>
	/// The messageReceiver GameObject will be sent the message "OnProximityChanged" when the prxomity changes
	/// </summary>
	public static GameObject messageReceiver{
		get{
			if (!instance){CreateInstance();}
			return _messageReciever;
		}
		set{
			if (!instance){CreateInstance();}
			_messageReciever = value;
		}
	}

	/// <summary>
	/// Method signature for a proximity delegate
	/// </summary>
	public delegate void ProximityDelegate(Proximity arg);

	/// <summary>
	/// The onProximityChange delegate will be called when the proximity changes
	/// </summary>
	public static ProximityDelegate onProximityChange{
		get{
			if(instance == null){CreateInstance();} 
			return _onProximityChange;
		} 
		set{
			if(instance == null){CreateInstance();} 
			_onProximityChange = value;
		} 
	} 

	/// <summary>
	/// Raises the proximity change event.
	/// </summary>
	/// <param name="newProximity">New proximity.</param>
	private void OnProximityChange(Proximity newProximity){
		if (onProximityChange != null){onProximityChange(newProximity);}
		if (messageReceiver != null){messageReceiver.SendMessage("OnProximityChange", newProximity, SendMessageOptions.DontRequireReceiver);} 
	}

	/// <summary>
	/// Creates the instance.
	/// </summary>
	private static void CreateInstance(){
		if (instance == null && Application.isPlaying){
			//create a hidden instance to recieve UnitySendMessageEvents
			instance = new GameObject("PAProximity").AddComponent<PAProximity>();
			instance.gameObject.hideFlags = HideFlags.HideAndDontSave;
			DontDestroyOnLoad(instance.gameObject);
		}
	}

	/// <summary>
	/// Clears the delegate to prevent method unsyncronization
	/// </summary>
	void OnDestroy(){
		_onProximityChange = null;
	}

	/// <summary>
	/// Method called by Android via UnitySendMessage 
	/// </summary>
	/// <param name="nearMessage">Contains "near" if the proximity is near </param>
	void OnSensorChanged(string nearMessage){
		//if the message is "near" then set near proximity 
		Proximity newProximity = (nearMessage == "true" ? Proximity.NEAR : Proximity.FAR);

		if (newProximity != proximity){
			proximity = newProximity;
			OnProximityChange(proximity); 
		}
	}

	void Start(){
#if UNITY_ANDROID && !UNITY_EDITOR
		//get the unity player class 
		AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		//get the paproximity class 
		AndroidJavaClass paProximityClass = new AndroidJavaClass("com.popupasylum.paproximity.PAProximity");
		//get the context to pass to Android 
		AndroidJavaObject activityContext = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

		//create an instance, set it's context and initiate 
		paProximity = paProximityClass.CallStatic<AndroidJavaObject>("instance");
		paProximity.Call("setContext", activityContext);
		paProximity.Call("init");

		//get starting proximity 
		FetchProximity();
#endif
	}

	/// <summary>
	/// Fetchs the proximity from android 
	/// </summary>
	void FetchProximity(){
#if UNITY_ANDROID && !UNITY_EDITOR
		if (paProximity != null){
			Proximity prox = paProximity.Call<bool>("getProximity") ? Proximity.NEAR : Proximity.FAR;
			if (prox != proximity) {
				proximity = prox;
				OnProximityChange(proximity); 
			}  
		}
#endif
	}

	/// <summary>
	/// Unregisters and reregisters to the sensor 
	/// </summary>
	/// <param name="pause">If set to <c>true</c> unregister listener.</param>
	void OnApplicationPause(bool pause){
#if UNITY_ANDROID && !UNITY_EDITOR
		if (paProximity != null){
			if (pause){
				paProximity.Call("unregisterListener");
			}else{
				paProximity.Call("registerListener");
			}
		}
#endif
	}
}
