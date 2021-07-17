using UnityEngine;
using UnityEngine.UI;

using  CookingPrototype.Controllers;

using TMPro;

namespace CookingPrototype.UI {
	public sealed class StartWindow : MonoBehaviour {
		public TMP_Text GoalText     = null;
		public Button   PlayButton = null;
		private GameplayController gc = GameplayController.Instance;

		bool _isInit = false;

		void Init() {
			gc = GameplayController.Instance;
			PlayButton.onClick.AddListener(gc.Play);
		}

		public void Show() {
			if ( !_isInit ) {
				Init();
			}

			/*var gc = GameplayController.Instance;*/
			
			GoalText.text = $"{gc.OrdersTarget}";

			gameObject.SetActive(true);
		}

		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}