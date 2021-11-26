using UnityEngine;
using System.Collections;

// ----- Low Poly FPS Pack Free Version -----
public class BulletScript : MonoBehaviour {

	[Range(5, 100)]
	[Tooltip("After how long time should the bullet prefab be destroyed?")]
	public float destroyAfter;
	[Tooltip("If enabled the bullet destroys on impact")]
	public bool destroyOnImpact = false;
	[Tooltip("Minimum time after impact that the bullet is destroyed")]
	public float minDestroyTime;
	[Tooltip("Maximum time after impact that the bullet is destroyed")]
	public float maxDestroyTime;

	[Header("Impact Effect Prefabs")]
	public Transform [] metalImpactPrefabs;

	private void Start () 
	{
		StartCoroutine (DestroyAfter ());
	}

	private void OnCollisionEnter (Collision collision) 
	{

		if (collision.transform.tag == "Enemy") 
		{
			//Instantiate random impact prefab from array
			Instantiate (metalImpactPrefabs [Random.Range 
				(0, metalImpactPrefabs.Length)], transform.position, 
				Quaternion.LookRotation (collision.contacts [0].normal));
			//Destroy bullet object
			Destroy(collision.gameObject);
		}

		if (collision.transform.tag == "Enemy") 
		{
			collision.transform.gameObject.GetComponent
				<TargetScript>().isHit = true;

			Destroy(collision.gameObject);
		}
			
		//If bullet collides with "ExplosiveBarrel" tag
	}

	private IEnumerator DestroyTimer () 
	{
		//Wait random time based on min and max values
		yield return new WaitForSeconds
			(Random.Range(minDestroyTime, maxDestroyTime));
		//Destroy bullet object
		Destroy(gameObject);
	}

	private IEnumerator DestroyAfter () 
	{
		//Wait for set amount of time
		yield return new WaitForSeconds (destroyAfter);
		//Destroy bullet object
		Destroy (gameObject);
	}
}