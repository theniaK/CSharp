using UnityEngine;
using System.Collections;

public class CoinSpin : MonoBehaviour {

	public float coinSpeed = 2;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Rotate(Vector3.up * coinSpeed);
	}
}
