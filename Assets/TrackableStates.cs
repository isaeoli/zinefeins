using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections;


public class TrackableStates : MonoBehaviour
{ 
    [SerializeField]
    ARTrackedImageManager m_ImageManager;

    void OnEnable() => m_ImageManager.trackablesChanged.AddListener(OnChanged);

    void OnDisable() => m_ImageManager.trackablesChanged.RemoveListener(OnChanged);

    void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {


        foreach (var newImage in eventArgs.added)
        {
            // Handle added event
            foreach(ARTrackable aRTrackable in m_ImageManager.trackables)
            {
                if(aRTrackable != newImage)
                {
                    aRTrackable.gameObject.SetActive(false);
                }
            }

        }

        foreach (var updatedImage in eventArgs.updated)
        {

            if(updatedImage.trackingState == TrackingState.Tracking)
            {
                updatedImage.gameObject.SetActive(true);
                Debug.Log("tracking found");

                foreach (ARTrackable aRTrackable in m_ImageManager.trackables)
                {
                    if (aRTrackable != updatedImage)
                    {
                        aRTrackable.gameObject.SetActive(false);
                    }
                }
            }

        }


        foreach (var removed in eventArgs.removed)
        {
            // Handle removed event
            TrackableId removedImageTrackableId = removed.Key;
            ARTrackedImage removedImage = removed.Value;
        }
    }

    
}
