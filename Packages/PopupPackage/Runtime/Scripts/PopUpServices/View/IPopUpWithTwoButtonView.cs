using System;

namespace Services.PopUp.View
{
    public interface IPopUpWithTwoButtonView
    {
        public Action ApproveButton { get; }
        public Action CancelButton { get; set; }
    }
}