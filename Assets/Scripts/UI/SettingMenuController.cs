using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingMenuController : MonoBehaviour {
    [SerializeField] UIDocument settingMenuUIDocument;
    [SerializeField] MainMenuController mainMenuController;

    private enum SheetType {
        Game,
        Graphic,
        Sound,
        None
    };

    private Button backButton;
    private Button gameSheetButton;
    private Button graphicSheetButton;
    private Button soundSheetButton;
    private VisualElement topElement;
    private VisualElement gameSheetTopElement;
    private VisualElement graphicSheetTopElement;
    private VisualElement soundSheetTopElement;
    private SheetType currentSheetType = SheetType.Game;

    private void OnEnable() {
        var rootElement = settingMenuUIDocument.rootVisualElement;
        topElement = rootElement.Q<VisualElement>("SettingMenuTop");
        backButton = rootElement.Q<Button>("BackButton");
        gameSheetButton = rootElement.Q<Button>("GameSheetButton");
        graphicSheetButton = rootElement.Q<Button>("GraphicSheetButton");
        soundSheetButton = rootElement.Q<Button>("SoundSheetButton");
        gameSheetTopElement = rootElement.Q<VisualElement>("GameSheetTop");
        graphicSheetTopElement = rootElement.Q<VisualElement>("GraphicSheetTop");
        soundSheetTopElement = rootElement.Q<VisualElement>("SoundSheetTop");

        backButton.clicked += OnClickBackButton;
        gameSheetButton.clicked += OnClickGameSheetButton;
        graphicSheetButton.clicked += OnClickGraphicSheetButton;
        soundSheetButton.clicked += OnClickSoundSheetButton;

        SetActiveUI(false);
    }

    private void OnDisable() {
        backButton.clicked -= OnClickBackButton;
        gameSheetButton.clicked -= OnClickGameSheetButton;
        graphicSheetButton.clicked -= OnClickGraphicSheetButton;
        soundSheetButton.clicked -= OnClickSoundSheetButton;
    }

    private void SwitchSheet(SheetType sheetType) {
        if (sheetType != SheetType.None) { currentSheetType = sheetType; }
        gameSheetTopElement.style.display = sheetType == SheetType.Game ? DisplayStyle.Flex : DisplayStyle.None;
        graphicSheetTopElement.style.display = sheetType == SheetType.Graphic ? DisplayStyle.Flex : DisplayStyle.None;
        soundSheetTopElement.style.display = sheetType == SheetType.Sound ? DisplayStyle.Flex : DisplayStyle.None;
    }

    private void OnClickGameSheetButton() {
        SwitchSheet(SheetType.Game);
    }

    private void OnClickGraphicSheetButton() {
        SwitchSheet(SheetType.Graphic);
    }

    private void OnClickSoundSheetButton() {
        SwitchSheet(SheetType.Sound);
    }

    private void OnClickBackButton() {
        SetActiveUI(false);
        mainMenuController.SetActiveUI(true);
    }

    public void SetActiveUI(bool value) {
        topElement.style.visibility = value ? Visibility.Visible : Visibility.Hidden;
        SwitchSheet(value ? currentSheetType : SheetType.None);
    }
}
