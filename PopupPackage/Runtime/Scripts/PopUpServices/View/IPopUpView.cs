using System;

namespace Services.PopUp.View
{
    public interface IPopUpView
    {
        public void OpenWithOneButton(string title, string body, Action onApproveAction = null);
        public void OpenWithTwoButton(string title, string body, Action onCancelAction = null, Action onApproveAction = null);
    }
}