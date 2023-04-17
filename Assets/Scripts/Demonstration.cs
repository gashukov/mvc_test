using UI.Core.Services;
using UI.Windows.MainWindow;
using UnityEngine;
using Zenject;

public class Demonstration : MonoBehaviour
{

    private IUIService _uiService;

    [Inject]
    public void Construct(IUIService uiService)
    {
        _uiService = uiService;
    }
        
    private void Start()
    {
        _uiService.OpenWindowDefault<MainWindowData>();
    }
}