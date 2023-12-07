using Services.PopUp;
using Services.PopUp.View;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExamplePopUp : MonoBehaviour
{
    public PopUpView PopUpViewPrefab;

    private PopUpService _popUpService;
    private int _countPopUps = 5;

    private void Awake()
    {
        _popUpService = new PopUpService(PopUpViewPrefab);
    }

    public void ShowPopUpWithOneButton()
    {
        _popUpService.Show("Title example text", "Body example text", OnApproveAction);
    }

    public void ShowPopUpWithTwoButton()
    {
        _popUpService.Show("Title example text", "Body example text", OnApproveAction, OnCancelAction);
    }

    private void OnApproveAction()
    {
        int number = Random.Range(0, 1000);
        Debug.Log($"Is clicked Approved {number}");
    }

    private void OnCancelAction()
    {
        int number = Random.Range(0, 1000);
        Debug.Log($"Is clicked cancel {number}");
    }
}