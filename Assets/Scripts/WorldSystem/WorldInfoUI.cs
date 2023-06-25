using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldInfoUI : MonoBehaviour
{
    [Header("Loading Panel")]
    [SerializeField] private GameObject _loadingPanel;
    [Header("Other Item")]
    [SerializeField] private Button _buttonAction;
    [SerializeField] private TextMeshProUGUI _buttonText;
    
    public void OpenLoading()
    {
        _loadingPanel.SetActive(true);
    }
    
    public void CloseLoading()
    {
        _loadingPanel.SetActive(false);
    }
    
    public void OpenButtonActionPanel(Action action, string textButton)
    {
        _buttonAction.gameObject.SetActive(true);
        _buttonText.text = textButton;
        _buttonAction.onClick.AddListener(() => action?.Invoke());
    }
    
    public void CloseButtonActionPanel()
    {
        _buttonAction.gameObject.SetActive(false);
        _buttonAction.onClick.RemoveAllListeners();
    }
}
