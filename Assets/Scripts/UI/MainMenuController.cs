using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour {
    [SerializeField] UIDocument mainMenuUIDocument;
    [SerializeField] SettingMenuController settingMenuController;

    private VisualElement topElement;
    private Button startButton;
    private Button settingButton;
    private Button exitButton;

    private void OnEnable() {
        var rootElement = mainMenuUIDocument.rootVisualElement;
        topElement = rootElement.Q<VisualElement>("MenuTop");
        startButton = rootElement.Q<Button>("StartButton");
        startButton.clicked += OnClickStartButton;

        settingButton = rootElement.Q<Button>("SettingButton");
        settingButton.clicked += OnClickSettingButton;

        exitButton = rootElement.Q<Button>("ExitButton");
        exitButton.clicked += OnClickExitButton;
    }

    private void OnDisable() {
        startButton.clicked -= OnClickStartButton;
        settingButton.clicked -= OnClickSettingButton;
        exitButton.clicked -= OnClickExitButton;
    }

    public void SetActiveUI(bool value) {
        topElement.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
    }

    private void OnClickStartButton() {
        Debug.Log("On Click Start Button");
    }
    private void OnClickSettingButton() {
        SetActiveUI(false);
        settingMenuController.SetActiveUI(true);
    }

    private void OnClickExitButton() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
