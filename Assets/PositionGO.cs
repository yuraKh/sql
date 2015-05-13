using UnityEngine;
using System.Collections;

public class PositionGO : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Q)) {
			transform.position = new Vector3 (Random.Range (-5, 5), transform.position.y, Random.Range (-5, 5));
		}
	}
}
