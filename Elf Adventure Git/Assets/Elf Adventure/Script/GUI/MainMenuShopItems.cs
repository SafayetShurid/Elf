using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuShopItems : MonoBehaviour {
	public int livePrice;
	public int bulletPrice;
    public int healthPrice;

	public AudioClip boughtSound;
	[Range(0,1)]
	public float boughtSoundVolume = 0.5f;

	public Text livePriceTxt;
	public Text bulletPriceTxt;
	public Text livesTxt;
	public Text bulletTxt;
    public Text HealthAmountText;
    public Text BulletAmountText;
    public Text healthPriceText;

	// Use this for initialization
	void Start () {

        healthPriceText.text = healthPrice.ToString();
		bulletPriceTxt.text = bulletPrice.ToString ();

       
	}

	void Update(){

        BulletAmountText.text = PlayerPrefs.GetInt(GlobalValue.Bullets,5).ToString();
        HealthAmountText.text = PlayerPrefs.GetInt(GlobalValue.Health,100).ToString();
        //Shurid
		//livesTxt.text = "Health Bonus: " + PlayerPrefs.GetInt (GlobalValue.Lives, 10);
		//bulletTxt.text = "Bullet: " + PlayerPrefs.GetInt (GlobalValue.Bullets, 3);

	}
	
	public void BuyLive(){
		var coins = PlayerPrefs.GetInt (GlobalValue.Coins, 0);
		if (coins >= livePrice) {
			coins -= livePrice;
			PlayerPrefs.SetInt (GlobalValue.Coins, coins);
			var lives = PlayerPrefs.GetInt (GlobalValue.Lives, 10);
			lives++;
			PlayerPrefs.SetInt (GlobalValue.Lives, lives);
			SoundManager.PlaySfx (boughtSound, boughtSoundVolume);
		}
	}

	public void BuyBullet(){
		var coins = PlayerPrefs.GetInt (GlobalValue.Coins, 0);
		if (coins >= bulletPrice) {
			coins -= bulletPrice;
			PlayerPrefs.SetInt (GlobalValue.Coins, coins);
			var bullets = PlayerPrefs.GetInt (GlobalValue.Bullets, 5);
			bullets++;
			PlayerPrefs.SetInt (GlobalValue.Bullets, bullets);
			SoundManager.PlaySfx (boughtSound, boughtSoundVolume);
		}
	}


    public void BuyHealth()
    {
        var coins = PlayerPrefs.GetInt(GlobalValue.Coins, 0);
        if (coins >= healthPrice)
        {
            coins -= healthPrice;
            PlayerPrefs.SetInt(GlobalValue.Coins, coins);
            var health = PlayerPrefs.GetInt(GlobalValue.Health, 10);
            health = health + 20;
            PlayerPrefs.SetInt(GlobalValue.Health, health);
            SoundManager.PlaySfx(boughtSound, boughtSoundVolume);
        }
    }
}
