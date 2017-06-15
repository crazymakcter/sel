using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class PlayerController : MonoBehaviour {
	
		private Rigidbody _rb;
		public Text HealtText;
		public Text GameOverText;
		public float MaxSpeed;

		private int _health;
	
		void Start () {
			_rb = GetComponent<Rigidbody>();
			_health = 100;
		}
	
		void Update () {
			if (_rb.velocity.magnitude > MaxSpeed)
			{
				_rb.velocity = _rb.velocity.normalized * MaxSpeed;
				//Debug.Log(_rb.velocity.magnitude);
			}
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Asteroid")
			{
				_health -= 5;
			}
			if (other.tag == "Medipack")
			{
				_health += 10;
				Destroy(other.gameObject);
			}
			HealtText.text = "+ " + _health + " %";

			if (_health > 0)
			{
				GameOverText.GetComponent<Text>().enabled = true;
			}
		}
	}
}
