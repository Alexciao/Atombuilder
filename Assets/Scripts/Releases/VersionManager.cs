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

    private void Start()
    {
        _versionText.text = CurrentVersion;
        CheckForUpdates();
    }

    async void CheckForUpdates()
    {
        GitHubClient client = new GitHubClient(new ProductHeaderValue(RepoName)); 
        IReadOnlyList<Release> releases = await client.Repository.Release.GetAll(RepoOwner, RepoName);
        Release latestRelease = releases[0];
        if (latestRelease.TagName != CurrentVersion)
        {
            _updatePopup.Open();
        }
    }
    
    public void OpenUpdateUrl()
    {
        UnityEngine.Application.OpenURL(_updateUrl);
    }
}
