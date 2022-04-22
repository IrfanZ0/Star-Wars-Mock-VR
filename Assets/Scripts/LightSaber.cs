using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.XR.Interaction.Toolkit;

public class LightSaber : MonoBehaviour
{
    Animator lightSaberAnim;
    AudioSource lightSaberSoundOn;
    AudioSource lightSaberSoundOff;
    public InputActionAsset lightSaberInputActionAsset;
    InputAction toggleOnAction;
    InputAction toggleOffAction;
    public XRRayInteractor rightRayInteractor;
    public XRRayInteractor leftRayInteractor;
    InputActionMap actionMapAsset;

    // Start is called before the first frame update
    void Start()
    {
        lightSaberAnim = GetComponent<Animator>();
        lightSaberSoundOn = GetComponent<AudioSource>();
        lightSaberSoundOff = GetComponent<AudioSource>();
        //player = GameObject.FindGameObjectWithTag("Player");

        //foreach (Transform child in player.transform.GetComponentInChildren<Transform>())
        //{
        //    if (child.name == "RightHand Controller")
        //    {
        //        rayInteractor = child.transform.Find("Right Ray Interactor").GetComponent<XRRayInteractor>();
        //    }
        //}

        

    }
    void Awake()
    {
        actionMapAsset = lightSaberInputActionAsset.FindActionMap("Light Saber");

       

        toggleOnAction = actionMapAsset.FindAction("ToggleOn");
        toggleOnAction.performed += LightSaberOn;
        toggleOnAction.Enable();

        toggleOffAction = actionMapAsset.FindAction("ToggleOff");
        toggleOffAction.performed += LightSaberOff;
        toggleOffAction.Enable();

    }

    private void LightSaberOff(InputAction.CallbackContext context)
    {
        if (context.action.name == "ToggleOff")
        {
            lightSaberOff();
        }
    }

    private void LightSaberOn(InputAction.CallbackContext context)
    {
        if (context.action.name == "ToggleOn")
        {
            lightSaberOn();
        }

       
    }

  


   

    private void lightSaberOff()
    {
        if (lightSaberSoundOff.clip.name == "Lightsaber Turn Off" && !lightSaberSoundOff.isPlaying)
        {
            lightSaberSoundOff.Play();
        }

        lightSaberAnim.SetBool("isOn", false);

    }

    private void lightSaberOn()
    {
       if (lightSaberSoundOn.clip.name == "Lightsaber Turn On" && !lightSaberSoundOn.isPlaying)
       {
            lightSaberSoundOn.Play();
       }

        lightSaberAnim.SetBool("isOn", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
