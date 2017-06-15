using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class GameController : MonoBehaviour
	{

		public GameObject Hazard;
		public Vector3 SpawnValues;
		public int ForcePower;
		public Text ScoreText;
		public int HazardCount;
		public int SpawnWait;

		private int _score;

		private PlayerController _player;

		void Start()
		{
			var playerObject = GameObject.FindWithTag("Player");
			if (playerObject != null)
			{
				_player = playerObject.GetComponent<PlayerController>();
			}

			StartCoroutine(SpawnWaves());
		}


		IEnumerator SpawnWaves()
		{

			while (true)
			{
				for (int i = 0; i < HazardCount; i++)
				{
					var randomValue = Random.Range(0, 10);
					var playerRbPosition = _player.GetComponent<Rigidbody>().position;
					if (randomValue > 5) randomValue = 1;
					else randomValue = -1;
					//Debug.Log(randomValue);
					Vector3 spawnPosition = new Vector3(
						playerRbPosition.x + Random.Range(-SpawnValues.x, SpawnValues.x),
						randomValue *SpawnValues.y + playerRbPosition.y,
						SpawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					var hazard = Instantiate(Hazard, spawnPosition, spawnRotation);
					hazard.GetComponent<Rigidbody>().AddForce(new Vector3(
						                                          playerRbPosition.x - spawnPosition.x,
						                                          playerRbPosition.y - spawnPosition.y, 0) *
					                                          ForcePower);
					yield return new WaitForSeconds(SpawnWait);
				}
				yield return new WaitForSeconds(SpawnWait);
			}
		}

		public void AddScore(string nameObject)
		{
			if (nameObject == "Bolt")
			{
				_score += 10;
			}
			ScoreText.text = "Score : " + _score;
		}
	}
}
