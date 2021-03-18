using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  [SerializeField]
  float movementSpeed = 3f; // Unity-enheter per sekund

  [SerializeField]
  float rotationSpeed = 150f; // Grader per sekund

  [SerializeField]
  GameObject bulletPrefab;

  [SerializeField]
  Transform bulletSpawnPoint;

  [SerializeField]
  float timeBetweenShots = 0.5f;
  float timeSinceLastShot = 0f;
	
	void Update () {

    float yRotation = Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
    float zMovement = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;

    Vector3 rotationVector = new Vector3(0, yRotation, 0);
    Vector3 movementVector = new Vector3(0, 0, zMovement);

    transform.Rotate(rotationVector);
    transform.Translate(movementVector);

    timeSinceLastShot += Time.deltaTime;

    if (Input.GetAxisRaw("Fire1") > 0)
    {
      if (timeSinceLastShot > timeBetweenShots)
      {
        Fire();
        timeSinceLastShot = 0;
      }
    }

	}

  void Fire()
  {
    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
  }
}
