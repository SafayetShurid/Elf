using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RewardVideo : MonoBehaviour
{
    string adUnitId= "ca-app-pub-4017585420796985/8439846192";
    AdRequest request;
    public Button reward;
    private RewardBasedVideoAd rewardBasedVideo;
   
    // Use this for initialization
    void Start()
    {
        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
       
        this.RequestRewardBasedVideo();
    }

    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-4017585420796985/1525622901";
#elif UNITY_IPHONE
string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
"HandleRewardBasedVideoFailedToLoad event received with message: "
+ args.Message);
        RequestRewardBasedVideo();

    }

public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
{
    MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
}

public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
{
    MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
}

public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
{
    MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
}

public void HandleRewardBasedVideoRewarded(object sender, Reward args)
{


        MenuManager.Instance.GotoCheckPoint();

    }

public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
{
    MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
}

public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
{
    print("Rewarded video ad failed to load: " +args.Message);
    // Handle the ad failed to load event.
}

public void ShowAd()
{
    if (rewardBasedVideo.IsLoaded())
    {
        rewardBasedVideo.Show();
           

    }
    RequestRewardBasedVideo();

}

  


}