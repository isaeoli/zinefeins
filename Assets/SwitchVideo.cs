using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using UnityEngine.Video;


public class SwitchVideo : MonoBehaviour
{

    public ARTrackedImage aRTrackedImage;

    public List<VideoClip> videoClips; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aRTrackedImage = GetComponent<ARTrackedImage>();

        Debug.Log(aRTrackedImage.referenceImage.name);


        foreach(VideoClip clip in videoClips)
        {
            if(aRTrackedImage.referenceImage.name == clip.name)
            {
                GetComponentInChildren<VideoPlayer>().clip = clip;
                Debug.Log("found");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
