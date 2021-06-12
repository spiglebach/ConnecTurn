using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoaderIcon : MonoBehaviour {
    [SerializeField] private int levelIndex = 1;
    private LevelLoader _levelLoader;
    private LevelProgress _levelProgress;
    private Button _button;
    private TMP_Text _text;
    private LevelStatus status;

    private void Start() {
        _levelLoader = FindObjectOfType<LevelLoader>();
        _levelProgress = FindObjectOfType<LevelProgress>();
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TMP_Text>();
        _text.text = levelIndex.ToString();
        status = _levelProgress.GetLevelStatus(levelIndex);
        var buttonColors = _button.colors;
        if (status == LevelStatus.Complete) {
            buttonColors.normalColor = Color.green;
        }
        if (status == LevelStatus.Current) {
            buttonColors.normalColor = new Color(1f, 0.9f, 0);
        }
        if (status == LevelStatus.Locked) {
            buttonColors.normalColor = Color.gray;
            _button.interactable = false;
        }
        _button.colors = buttonColors;
    }

    public void LoadLevelIfUnlocked() {
        if (!_levelLoader || status == LevelStatus.Locked) return;
        _levelLoader.LoadLevelIfUnlocked(levelIndex);
    }
}
