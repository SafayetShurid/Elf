using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetData : MonoBehaviour {
	SoundManager soundManager;
    public Text coinText;

	void Start(){
		soundManager = FindObjectOfType<SoundManager> ();
	}

	public void Reset(){
		PlayerPrefs.DeleteAll ();
		LoadingSreen.Show ();
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);

		SoundManager.PlaySfx (soundManager.soundClick);
	}

	public void UnlockAll(){
		PlayerPrefs.SetInt (GlobalValue.WorldReached, int.MaxValue);
		for (int i = 1; i < 100; i++) {
			PlayerPrefs.SetInt (i.ToString (), 10000);		//world i, unlock 10000 levels
		}
        gameObject.SetActive(false);
		// LoadingSreen.Show ();
		//SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);

		//SoundManager.PlaySfx (soundManager.soundClick);
	}

    public void FREECOIN()
    {
        int coin = PlayerPrefs.GetInt(GlobalValue.Coins,0);
        coin += 1000;
        PlayerPrefs.SetInt(GlobalValue.Coins, coin);
        coinText.text = PlayerPrefs.GetInt(GlobalValue.Coins, 0).ToString();

    }
}
