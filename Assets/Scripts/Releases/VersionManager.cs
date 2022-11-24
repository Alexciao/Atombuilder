using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Octokit;

public class VersionManager : MonoBehaviour
{
    public static readonly string CurrentVersion = "v1.3.0";
    public static readonly string RepoOwner = "Alexciao";
    public static readonly string RepoName = "Atombuilder";

    [Header("References")]
    [SerializeField] private TextMeshProUGUI _versionText;
    [Space]
    [SerializeField] private PopupManager _updatePopup;

    [SerializeField] private QuitManager _quit;

    [Header("Settings")] 
    public string _updateUrl = "https://github.com/" + RepoOwner + "/" + RepoName + "/releases/latest";
    [SerializeField] private bool _repoNameInVersion = false;
    [SerializeField] private bool _quitOnUpdate = true;

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
        Release latestRelease = GetLatestRelease();
        if (latestRelease.TagName != CurrentVersion && !latestRelease.Prerelease)
        {
            Debug.Log("Latest version " + "(" + latestRelease.TagName + ")" + " is different from current version " + "(" + CurrentVersion + ")");
            _updatePopup.Open();
        }
    }

    Release GetLatestRelease()
    {
        GitHubClient client = new GitHubClient(new ProductHeaderValue(RepoName)); 
        IReadOnlyList<Release> releases = client.Repository.Release.GetAll(RepoOwner, RepoName).Result;
        Release latestRelease = releases[0];
        return latestRelease;
    }
    
    public void OpenUpdateUrl()
    {
        UnityEngine.Application.OpenURL(_updateUrl);
        if (_quitOnUpdate) _quit.Quit();
    }
}
