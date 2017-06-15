using UnityEngine;

namespace Assets.Scripts
{
	public class DestroyByContact : MonoBehaviour
	{

		public GameObject Explosion;
		public GameObject MedicalPack;
		private GameController _gameController;

		void Start()
		{
			var gameControllerObject = GameObject.FindWithTag("GameController");
			if (gameControllerObject != null)
			{
				_gameController = gameControllerObject.GetComponent<GameController>();
			}
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Medipack")
			{
				return;
			}
			if (other.tag == "Bolt")
			{
				_gameController.AddScore("Bolt");
				if (Random.Range(1, 10) > 7)
				{
					Instantiate(MedicalPack, transform.position, transform.rotation);
				}
			}
			Instantiate(Explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
