using DigitalRuby.ThunderAndLightning;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerAttacks : MonoBehaviour
{
    public InputActionAsset playerInputActionAsset;
    InputAction lightning;
    InputAction hoverObject;
    InputAction grabObject;
    InputAction releaseObject;
    InputActionMap playerActionMap;
    private LightningBoltPathScript lBoltScript;
    Vector3 startPos;
    Vector3 endPos;
    XRRayInteractor leftRayInteractor;
    XRRayInteractor rightRayInteractor;
    XRDirectInteractor leftHandDirectInteractor;
    XRDirectInteractor rightHandDirectInteractor;
    RaycastHit hit;
    HoverEnterEventArgs args;

    public float hoverHeight = 1f;
    public float hoverSpeed = 1.5f;
    public float hoverRange = 2f;
    float forceMultiplier = 4f;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.name == "LightningRayPath")
            {
                lBoltScript = child.GetComponent<LightningBoltPathScript>();
            }

            if (child.name == "Left Ray Interactor")
            {
                leftRayInteractor = child.GetComponent<XRRayInteractor>();
            }

            if (child.name == "Right Ray Interactor")
            {
                rightRayInteractor = child.GetComponent<XRRayInteractor>();
            }

            if (child.name == "LeftHand Controller")
            {
                leftHandDirectInteractor = child.GetComponent<XRDirectInteractor>();
            }

            if (child.name == "RightHand Controller")
            {
                rightHandDirectInteractor = child.GetComponent<XRDirectInteractor>();
            }
        }

        args = new HoverEnterEventArgs();
    }

    void Awake()
    {
        playerActionMap = playerInputActionAsset.FindActionMap("Player");

        lightning = playerActionMap.FindAction("Lightning");
        lightning.performed += CreateLightningBolt;
        lightning.Enable();

        hoverObject = playerActionMap.FindAction("Hover");
        hoverObject.performed += HoverObject;
        hoverObject.Enable();

        grabObject = playerActionMap.FindAction("Grab");
        grabObject.performed += GrabObject;
        grabObject.Enable();

        releaseObject = playerActionMap.FindAction("Release");
        releaseObject.performed += ReleaseObject;
        releaseObject.Enable();

       
    }

    private void ReleaseObject(InputAction.CallbackContext context)
    {
        if (context.action.name == "Release")
        {
          
        }
    }

    private void Selected(SelectEnterEventArgs args)
    {
        args.interactableObject.transform.position = Vector3.Lerp(args.interactableObject.transform.position, transform.position, Time.deltaTime * hoverSpeed);
    }

    private void GrabObject(InputAction.CallbackContext context)
    {
        if (context.action.name == "Grab")
        {
            if (leftRayInteractor.TryGetCurrent3DRaycastHit(out hit))
            {
                GameObject leftTargetInteractable = hit.collider.gameObject;
                XRGrabInteractable leftGrabInteractable = leftTargetInteractable.GetComponent<XRGrabInteractable>();
                leftGrabInteractable.selectEntered.AddListener(Selected);

                leftRayInteractor.useForceGrab = true;

            }

            if (rightRayInteractor.TryGetCurrent3DRaycastHit(out hit))
            {
                GameObject rightTargetInteractable = hit.collider.gameObject;
                XRGrabInteractable rightGrabInteractable = rightTargetInteractable.GetComponent<XRGrabInteractable>();
                rightGrabInteractable.selectEntered.AddListener(Selected);

               rightRayInteractor.useForceGrab = true;

            }
            
           
        }
    }
    
    private void HoverObject(InputAction.CallbackContext context)
    {
       if (context.action.name == "Hover")
       {
            
              if (leftRayInteractor.TryGetCurrent3DRaycastHit(out hit))
              {
                    GameObject leftTargetInteractable = hit.collider.gameObject;
                    XRGrabInteractable leftGrabInteractable = leftTargetInteractable.GetComponent<XRGrabInteractable>();
                    leftGrabInteractable.hoverEntered.AddListener(Hover);

                

              }

            if (rightRayInteractor.TryGetCurrent3DRaycastHit(out hit))
            {
                GameObject rightTargetInteractable = hit.collider.gameObject;
                XRGrabInteractable rightGrabInteractable = rightTargetInteractable.GetComponent<XRGrabInteractable>();
                rightGrabInteractable.hoverEntered.AddListener(Hover);
                              

            }
        }
    }
    
    private void Hover(HoverEnterEventArgs args)
    {
        args.interactableObject.transform.position = Vector3.up * hoverHeight * Mathf.Cos(Time.time * hoverSpeed);
    }

   

    private void CreateLightningBolt(InputAction.CallbackContext context)
    {
        if (context.action.name == "Lightning")
        {
            startPos = leftRayInteractor.transform.position;
            startPos.z = leftRayInteractor.maxRaycastDistance;
            endPos = new Vector3(startPos.x, startPos.y, startPos.z);
            lBoltScript.Trigger(startPos, endPos);
           
        }
       
    }

   
}
