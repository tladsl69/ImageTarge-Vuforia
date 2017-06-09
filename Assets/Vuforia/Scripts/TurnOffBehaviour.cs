/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A utility behaviour to disable rendering of a game object at run time.
    /// </summary>
    public class TurnOffBehaviour : TurnOffAbstractBehaviour
    {

        #region UNITY_MONOBEHAVIOUR_METHODS
		void Awake(){
			

            if (VuforiaRuntimeUtilities.IsVuforiaEnabled())
            {
                // We remove the mesh components at run-time only, but keep them for
                // visualization when running in the editor:
                MeshRenderer targetMeshRenderer = this.GetComponent<MeshRenderer>();
                Destroy(targetMeshRenderer);
                MeshFilter targetMesh = this.GetComponent<MeshFilter>();
                Destroy(targetMesh);
            }
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

        #endregion // UNITY_MONOBEHAVIOUR_METHODS

    }
}
