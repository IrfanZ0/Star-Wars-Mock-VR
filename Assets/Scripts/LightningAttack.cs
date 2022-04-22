using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAttack : MonoBehaviour
{
    ParticleSystem lightningPS;
    List<ParticleCollisionEvent> particleCollisionEvents;
    float forceFactor = 5f;
    public GameObject lightningSphereGO;
    GameObject lightningSphere;

    // Start is called before the first frame update
    void Start()
    {
        lightningPS = GetComponent<ParticleSystem>();
        particleCollisionEvents = new List<ParticleCollisionEvent>();
        
    }

    // Update is called once per frame
    void OnParticleCollision (GameObject other)
    {
        int numCollisions = lightningPS.GetCollisionEvents(other, particleCollisionEvents);
        Rigidbody rbTarget = other.GetComponent<Rigidbody>();

        int i = 0;

        if (i < numCollisions)
        {
            Vector3 damagePosition = particleCollisionEvents[i].intersection;
            Vector3 particleForce = particleCollisionEvents[i].velocity * forceFactor;

            lightningSphere = Instantiate(lightningSphereGO, damagePosition, other.transform.rotation);
            rbTarget.AddForce(particleForce);
            i++;


        }

        Destroy(lightningSphere.gameObject, 3f);
    }
}
