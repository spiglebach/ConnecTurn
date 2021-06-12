using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    private LevelProgress _levelProgress;

    private void Start() {
        _levelProgress = FindObjectOfType<LevelProgress>();
    }

    public void LoadNextLevel() {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void LoadLevelSelector() {
        SceneManager.LoadScene("Level Selector");
    }

    public void ReloadCurrentLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LevelComplete() {
        var levelIndex = SceneManager.GetActiveScene().buildIndex;
        _levelProgress.LevelComplete(levelIndex);
    }

    public void ResetProgress() {
        _levelProgress.ResetProgress();
        ReloadCurrentLevel();
    }

    public void LoadLevelIfUnlocked(int buildIndex) {
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadSettings() {
        SceneManager.LoadScene("Settings");
    }
}

public enum LevelStatus {
    Complete,
    Current,
    Locked
}