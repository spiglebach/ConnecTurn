using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour {
    private int completeLevels = -1;
    private const string COMPLETE_LEVELS_KEY = "COMPLETE_LEVELS";
    private void Awake() {
        if (FindObjectsOfType<LevelProgress>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LevelComplete() {
        LevelComplete(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelComplete(int levelIndex) {
        FetchCompleteLevelsIfNotSet();
        if (levelIndex > completeLevels) {
            completeLevels = levelIndex;
        }
        PlayerPrefs.SetInt(COMPLETE_LEVELS_KEY, completeLevels);
        PlayerPrefs.Save();
    }

    public void ResetProgress() {
        completeLevels = 0;
        PlayerPrefs.SetInt(COMPLETE_LEVELS_KEY, completeLevels);
        PlayerPrefs.Save();
    }

    public int GetCompleteLevels() {
        FetchCompleteLevelsIfNotSet();
        return completeLevels;
    }

    private void FetchCompleteLevelsIfNotSet() {
        if (completeLevels == -1) {
            completeLevels = PlayerPrefs.GetInt(COMPLETE_LEVELS_KEY, 0);
        }
    }
    
    public LevelStatus GetLevelStatus(int levelNumber) {
        FetchCompleteLevelsIfNotSet();
        if (levelNumber <= completeLevels) {
            return LevelStatus.Complete;
        }
        if (levelNumber == completeLevels + 1) {
            return LevelStatus.Current;
        }
        return LevelStatus.Locked;
    }
}
