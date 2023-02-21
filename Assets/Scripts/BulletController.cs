using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BulletController : NetworkBehaviour
{

    [SerializeField]
    float initialVelocity = 6;

    [SerializeField]
    float lifeTime = 4;

    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * initialVelocity;

        Destroy(this.gameObject, lifeTime);
    }
}
