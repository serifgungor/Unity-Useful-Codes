using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class AssetsBundleFromUrl : MonoBehaviour
{
    public string assetName;
    private AssetBundle assetBundle;

    void Start()
{
        assetName = "demo";
    StartCoroutine(DownloadAsset());
}

IEnumerator DownloadAsset()
{
        //Download asset bundle
        WWW bundleWWW = WWW.LoadFromCacheOrDownload("http://localhost/demo", 1);
        yield return bundleWWW;
        assetBundle = bundleWWW.assetBundle;

        if (assetBundle.isStreamedSceneAssetBundle)
        {
            string[] scenePaths = assetBundle.GetAllScenePaths();
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePaths[0]);
            Application.LoadLevel(sceneName);
        }

    }
}

//https://docs.unity3d.com/Manual/AssetBundles-Workflow.html
