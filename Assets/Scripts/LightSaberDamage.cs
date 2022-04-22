using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberDamage : MonoBehaviour
{
    float forceMultiplier = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Rigidbody rbEnemy = coll.gameObject.GetComponent<Rigidbody>();
            rbEnemy.AddForce(Vector3.forward * forceMultiplier, ForceMode.Force);
        }
    }
}
