 using UnityEngine;
using UnityEngine.Advertisements;

public class InitAds : MonoBehaviour, IUnityAdsInitializationListener
{
    string AndroidGameId = "5030833";
    bool testMode;

    string androidadunitId = "Banner_Android";
    string adunitId;
    // Start is called before the first frame update
    void Start()
    {
        adunitId = androidadunitId;
        testMode = true;
        InitializeAds();
    }

    void InitializeAds()
    {
        var gameId = AndroidGameId;
        Advertisement.Initialize(gameId, testMode, this);
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    }

    // Update is called once per frame
    void Update()
    {
        Advertisement.Banner.Show(adunitId);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log(message + " " + error);
    }
}
