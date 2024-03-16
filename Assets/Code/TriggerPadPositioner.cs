using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPadPositioner : MonoBehaviour
{
    [SerializeField] private OVRControllerHelper rightController;
    [Range(0, 0.5f)] [SerializeField] private float yOffset;
    
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            var pos = rightController.transform.position;
            pos.y -= yOffset;
            gameObject.transform.position = pos;
        }
    }
}
