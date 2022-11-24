using TMPro;
using UnityEngine;
using Octokit;

public class VersionManager : MonoBehaviour
{
    public static readonly string CurrentVersion = "v1.2.1";
    public static readonly string RepoOwner = "Alexciao";
    public static readonly string RepoName = "Atombuilder";

    [Header("References")]
    [SerializeField] private TextMeshProUGUI _versionText;
    [Space]
    [SerializeField] private PopupManager _updatePopup;

    [Header("Settings")] [SerializeField] private string _updateUrl = "https://github.com/" + RepoOwner + "/" + RepoName + "/releases/latest";

    private void Start()
    {
        _versionText.text = CurrentVersion;
        CheckForUpdates();
    }

    async void CheckForUpdates()
    {
        GitHubClient client = new GitHubClient(new ProductHeaderValue(RepoName));
        var releases = await client.Repository.Release.GetAll(RepoOwner, RepoName);
        var latestRelease = releases[0];
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
