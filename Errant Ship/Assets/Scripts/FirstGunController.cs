using UnityEngine;

namespace Assets.Scripts
{
	public class FirstGunController : MonoBehaviour {

		public int SpeedRotation;
		
		public GameObject Shot;
		public Transform ShotSpawn;
		private float _fireRate = 0.3f;
		private float _nextFire = 0.5f;

		public int ForcePower;
		
		private PlayerController _player;
		
		void Start () {
			var playerObject = GameObject.FindWithTag("Player");
			if (playerObject != null)
			{
				_player = playerObject.GetComponent<PlayerController>();
			}
		}
	
		void Update () {
			if (Input.GetButton("Fire1") && Time.time > _nextFire)
			{
				_nextFire = Time.time + _fireRate;
				var clone = Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation) as GameObject;
				clone.GetComponent<AudioSource>().Play();
				//clone.GetComponent<Rigidbody>().velocity = _player.GetComponent<Rigidbody>().velocity*2;

				_player.GetComponent<Rigidbody>()
					.AddForce(new Vector3(_player.GetComponent<Rigidbody>().position.x - ShotSpawn.position.x,
						          _player.GetComponent<Rigidbody>().position.y - ShotSpawn.position.y, 0) * ForcePower);
			}
		}
	
		void FixedUpdate ()
		{
			var inputfirstPlayer = Input.GetAxis("Horizontal");
			transform.rotation *= Quaternion.Euler(0f, 0f, inputfirstPlayer*SpeedRotation*Time.deltaTime);
		}
	}
}
