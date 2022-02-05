using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public static float speed = 0.1f;
	void Update ()
	{
		
		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (-10.0f, transform.position.y, transform.position.z), speed+0.3f);
		//GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0) * speed;
		//speed += 0.05f;
		if (transform.position.x < -9){
			Destroy(this.gameObject);
		}
		
	}


}
