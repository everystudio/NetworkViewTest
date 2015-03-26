using UnityEngine;
using System.Collections;
using gui = UnityEngine.GUI;

public class GameMain : MonoBehaviour {

	public GameObject playerPrefab;
	string ip = "127.0.0.1";
	string port = "4211";
	Camera camera;

	bool connected;

	public void CreatePlayer(){
		connected = true;
		var g = (GameObject)Network.Instantiate (playerPrefab, transform.position, transform.rotation, 1);
		g.GetComponentInChildren<Camera> ().enabled = true;
		camera.enabled = false;
	}

	void OnDisconnectedFromServer(){
		connected = false;
	}

	void OnPlayerDisconnected(NetworkPlayer pl){
		Network.DestroyPlayerObjects (pl);
	}

	void OnConnectedToServer(){
		CreatePlayer ();
	}

	void OnServerInitialized(){
		CreatePlayer ();
	}

	void OnGUI(){
		if (!connected) {
			ip = gui.TextField (new Rect (10, 10, 90, 20), ip);
			port = gui.TextField( new Rect( 10,40,90,20),port);
		}
		if (gui.Button (new Rect (10, 70, 90, 20), "connect")) {
			Network.Connect (ip, int.Parse (port));
		}
		if (gui.Button (new Rect (10, 100, 90, 20), "host")) {
			Network.InitializeServer (10, int.Parse (port), false);
		}
	}

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
