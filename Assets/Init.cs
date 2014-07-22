using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {

	public GameObject goPlane;
	// Use this for initialization
	void Start () {
		goPlane = GameObject.Find ("Plane");
		for (int i=0; i<4; i++) {
			for(int j=0; j< 4;j++)
			{
				GameObject go=GameObject .CreatePrimitive(PrimitiveType.Cube);
				go.transform.position=new Vector3(i,j,0);
				go.AddComponent<Rigidbody>();
				go.AddComponent<AutoDestroy>();
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			GameObject goBullet=GameObject.CreatePrimitive(PrimitiveType.Sphere);
			goBullet.transform.position=Camera.main.transform.position;
			goBullet.AddComponent<Rigidbody>();
			goBullet.AddComponent<AutoDestroy>();
			goPlane.AddComponent<AudioSource>().Play();
			//GameObject goPlane=GameObject.Find("Plane");

			Vector3 targetPos=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,3));
			goBullet.rigidbody.AddForce((targetPos-Camera.main.transform.position)*10,ForceMode.Impulse);

			GameObject.Find("goBullet");
				Destroy(goBullet,1);
		}
	}
}
