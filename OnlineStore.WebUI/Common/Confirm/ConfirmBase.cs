using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace OnlineStore.WebUI.Common.Confirm
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter]
        public string ConfirmationTitle { get; set; }

        [Parameter]
        public string ConfirmationMessage { get; set; }

        public void Show(string title, string message)
        {
            ConfirmationTitle = title;
            ConfirmationMessage = message;
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }
}