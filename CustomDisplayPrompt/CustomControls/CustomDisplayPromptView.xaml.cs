using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomDisplayPrompt.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomDisplayPromptView : ContentPage
    {
        private readonly string ID;
        private readonly string title;
        private readonly string text;
        private readonly dynamic Component;
        private readonly EventHandler eventHandler;
        public CustomDisplayPromptView(dynamic Component, string ID, string title, string text, EventHandler eventHandler)
        {
            InitializeComponent();
            this.ID = ID;
            this.title = title;
            this.text = text;
            this.Component = Component;
            this.eventHandler = eventHandler;
            this.LayoutChanged += CustomDisplayPromptView_LayoutChanged;

            lblSelectedField.Text = title;
            edtInput.Text = text;
        }

        private void CustomDisplayPromptView_LayoutChanged(object sender, EventArgs e)
        {
            edtInput.HeightRequest = Main.HeightRequest;
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                if (Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
                {
                    AbsoluteLayout.SetLayoutBounds(Main, new Rectangle(0.5, 0.5, 0.8, 0.8));
                }
                else
                {
                    AbsoluteLayout.SetLayoutBounds(Main, new Rectangle(0.5, 0.5, 0.8, 0.8));
                }
            }
            else if (Device.RuntimePlatform == Device.UWP || Device.Idiom == TargetIdiom.Tablet)
            {
                AbsoluteLayout.SetLayoutBounds(Main, new Rectangle(0.5, 0.5, 0.5, 0.5));

            }
            else
            {
                AbsoluteLayout.SetLayoutBounds(Main, new Rectangle(0.5, 0.5, 0.8, 0.8));
            }

            AbsoluteLayout.SetLayoutFlags(Main, AbsoluteLayoutFlags.All);
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<Page, string>(this, ID, edtInput.Text);
            await Task.Delay(50);
            eventHandler(null, null);
            Navigation.PopModalAsync();
        }
    }
}