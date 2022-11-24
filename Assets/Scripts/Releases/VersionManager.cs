using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Octokit;

public class VersionManager : MonoBehaviour
{
    public static readonly string CurrentVersion = "v1.2.2";
    public static readonly string RepoOwner = "Alexciao";
    public static readonly string RepoName = "Atombuilder";

    [Header("References")]
    [SerializeField] private TextMeshProUGUI _versionText;
    [Space]
    [SerializeField] private PopupManager _updatePopup;

    [Header("Settings")] 
    public string _updateUrl = "https://github.com/" + RepoOwner + "/" + RepoName + "/releases/latest";
    [SerializeField] private bool _repoNameInVersion = false;

    private void Start()
    {
        SetVersionText(_versionText, _repoNameInVersion);
        CheckForUpdates();
    }

    private void SetVersionText(TextMeshProUGUI text, bool addRepoName = true)
    {
        if (addRepoName) text.text = RepoName + " " + CurrentVersion;
        else text.text = CurrentVersion;
    }
    
    async void CheckForUpdates()
    {
        Debug.Log("Checking for updates...");
        GitHubClient client = new GitHubClient(new ProductHeaderValue(RepoName)); 
        IReadOnlyList<Release> releases = await client.Repository.Release.GetAll(RepoOwner, RepoName);
        Release latestRelease = releases[0];
        if (latestRelease.TagName != CurrentVersion)
        {
            Debug.Log("Latest version " + "(" + latestRelease.TagName + ")" + " is different from current version " + "(" + CurrentVersion + ")");
            _updatePopup.Open();
        }
        else
        {
            Debug.Log("No new version available.");
        }
    }
    
    public void OpenUpdateUrl()
    {
        UnityEngine.Application.OpenURL(_updateUrl);
    }
}
