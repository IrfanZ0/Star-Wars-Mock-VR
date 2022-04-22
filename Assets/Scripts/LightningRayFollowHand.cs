using DigitalRuby.ThunderAndLightning;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRayFollowHand : MonoBehaviour
{
    LightningBeamSpellScript lBeamScript;
    public GameObject leftInteractor;
    Transform startPosition;
    Transform endPosition;

    // Start is called before the first frame update
    void Start()
    {
        lBeamScript = GetComponent<LightningBeamSpellScript>();
        startPosition = lBeamScript.SpellStart.transform;
        endPosition = lBeamScript.SpellEnd.transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveLightningBeam();
    }

    private void MoveLightningBeam()
    {
        transform.parent = leftInteractor.transform;
        transform.position = Vector3.zero;
       
    }
}
