using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
//using UnityEngine.Experimental.XR

using UnityEngine.XR.ARSubsystems;
using System;

public class ARCast : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject objectToPlace;
    private Pose placementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;
    private bool placed = false;


    void Start()
    {
        //arOrigin = FindObjectOfType<ARSessionOrigin>();
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        objectToPlace.SetActive(false);
    }

    void Update()
    {
        if (!placed) {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
                    //Place on click
            if(placementPoseIsValid && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) {
                PlaceObject();
                placed = true;
                placementIndicator.SetActive(false);
            }
        }
    }


    private void PlaceObject() {
        objectToPlace.SetActive(true);
        objectToPlace.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
    }
    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
		{
            placementIndicator.SetActive(false);
		}
	}

    private void UpdatePlacementPose()
	{
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.All);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
		{
            placementPose = hits[0].pose;
		}
	}
}