using UnityEngine;

namespace Assets.Scripts
{
	public class CameraController : MonoBehaviour
	{

		public GameObject Player;
		private Vector3 _vectorOffSet;

		void Start ()
		{
			_vectorOffSet = transform.position - Player.transform.position;
		}
	
		// Update is called once per frame
		void LateUpdate () {
			transform.position = Player.transform.position + _vectorOffSet;
		}
	}
}
