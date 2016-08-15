using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	
	// Update is called once per frame
	void Update() {

		if (!isLocalPlayer) {
			return;
		}
		//Debug.Log("move");
		float rotation = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float translation = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, rotation, 0);
		transform.Translate(0, 0, translation);

		if (Input.GetKeyDown(KeyCode.Space)) {
			Fire();
		}
	}


	// Only runs this on your
	public override void OnStartLocalPlayer() {
		base.OnStartLocalPlayer();
		GetComponent<MeshRenderer>().material.color = Color.yellow;
	}

	void Fire() {
		GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;
		Destroy(bullet, 2);
	}
}
