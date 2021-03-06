﻿/*============================================================================== 
 Copyright (c) 2016 PTC Inc. All Rights Reserved.
 
 Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections;


public class ModelSwap : MonoBehaviour 
{
	GameObject mDefaultModel;
	GameObject mExtTrackedModel;
	GameObject mActiveModel = null;
	TrackableSettings mTrackableSettings = null;

	void Start () 
    {
        mDefaultModel = this.transform.FindChild("teapot").gameObject;
        mExtTrackedModel = this.transform.FindChild("tower").gameObject;
        mActiveModel = mDefaultModel;
        mTrackableSettings = FindObjectOfType<TrackableSettings>();
    }
    
    void Update () 
    {
        if (mTrackableSettings.IsExtendedTrackingEnabled() && (mActiveModel == mDefaultModel))
        {
            // Switch 3D model to tower
            mDefaultModel.SetActive(false);
            mExtTrackedModel.SetActive(true);
            mActiveModel = mExtTrackedModel;
        }
        else if (!mTrackableSettings.IsExtendedTrackingEnabled() && (mActiveModel == mExtTrackedModel))
        {
            // Switch 3D model to teapot
            mExtTrackedModel.SetActive(false);
            mDefaultModel.SetActive(true);
            mActiveModel = mDefaultModel;
        }
    }
}
