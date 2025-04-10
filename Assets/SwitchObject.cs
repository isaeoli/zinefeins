using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using UnityEngine.Video;


public class SwitchObject : MonoBehaviour
{

    public ARTrackedImage aRTrackedImage;

    public List<GameObject> objects; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aRTrackedImage = GetComponent<ARTrackedImage>();

        Debug.Log(aRTrackedImage.referenceImage.name);


        foreach(GameObject newObject in objects)
        {
            if(aRTrackedImage.referenceImage.name == newObject.name)
            {
                Instantiate(newObject, gameObject.transform);
                Debug.Log("found");
            }
        }
    }

}
