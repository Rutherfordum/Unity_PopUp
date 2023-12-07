using System;
using TMPro;
using UnityEngine;

namespace Services.PopUp.View
{
    public sealed class PopUpView : MonoBehaviour, IPopUpView
    {
        [SerializeField] private GameObject popUpScreen;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI bodyText;
        [SerializeField] private PopUpWithOneButtonView popUpWithOneButtonView;
        [SerializeField] private PopUpWithTwoButtonView popUpWithTwoButtonView;

        private void Awake()
        {
            titleText.text = "Title message";
            bodyText.text = "Body message";

            popUpWithOneButtonView.ApproveButton += Close;
            popUpWithTwoButtonView.ApproveButton += Close;
            popUpWithTwoButtonView.CancelButton += Close;
        }

        private void OnDestroy()
        {
            popUpWithOneButtonView.ApproveButton -= Close;
            popUpWithTwoButtonView.ApproveButton -= Close;
            popUpWithTwoButtonView.CancelButton -= Close;
        }

        public void OpenWithOneButton(string title, string body, Action onApproveAction)
        {
            titleText.text = title;
            bodyText.text = body;
            popUpScreen.SetActive(true);
            popUpWithOneButtonView.gameObject.SetActive(true);

            popUpWithOneButtonView.ApproveButton -= onApproveAction;
            popUpWithOneButtonView.ApproveButton += onApproveAction;
        }

        public void OpenWithTwoButton(string title, string body, Action onCancelAction = null, Action onApproveAction = null)
        {
            titleText.text = title;
            bodyText.text = body;
            popUpScreen.SetActive(true);
            popUpWithTwoButtonView.gameObject.SetActive(true);
            
            popUpWithTwoButtonView.ApproveButton -= onApproveAction;
            popUpWithTwoButtonView.ApproveButton += onApproveAction;
            
            popUpWithTwoButtonView.CancelButton -= onCancelAction;
            popUpWithTwoButtonView.CancelButton += onCancelAction;

        }

        private void Close()
        {
            titleText.text = "Title message";
            bodyText.text = "Body message";

            popUpWithOneButtonView.gameObject.SetActive(false);
            popUpWithTwoButtonView.gameObject.SetActive(false);
            popUpScreen.SetActive(false);
        }
    }
}