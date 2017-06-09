using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class testLoad : MonoBehaviour {

	void Awake(){
		UpdateConfiguration ("ImageTargets");
	}
//	void OnGUI(){
//		if(GUILayout.Button("Image Target",GUILayout.Width(100),GUILayout.Height(50))){
//			UpdateConfiguration ("ImageTargets");
//		}
//	}
		

	public void UpdateConfiguration(string scene)
	{

		var config = VuforiaConfiguration.Instance;
		var dbConfig = config.DatabaseLoad;
		var stConfig = config.SmartTerrainTracker;

		// all settings which are changed for a scene, have to be reset here
		// because any change is persistent throughout the whole application
		dbConfig.DataSetsToLoad = dbConfig.DataSetsToActivate = new string[0];
		stConfig.AutoInitAndStartTracker = stConfig.AutoInitBuilder = false;
		config.Vuforia.MaxSimultaneousImageTargets = 1;

		dbConfig.DataSetsToLoad = new[] {"StonesAndChips", "Tarmac"};
		dbConfig.DataSetsToActivate = new[] { "StonesAndChips" };
	}
}
