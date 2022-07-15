using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CustomDisplayPrompt.CustomControls
{
    public class CustomDisplayPrompt : CustomLabel
    {
        public CustomDisplayPrompt()
        {
            MessagingCenter.Subscribe<Page, string>(this, this.Id.ToString(), (p, value) =>
            {
                Text = value;
            });
            this.Tapped += CustomDisplayPrompt_Tapped;
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(String), typeof(CustomDisplayPrompt), "Type a Value", BindingMode.TwoWay);
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        private readonly object _tappedEventPadlock = new object();

        public event EventHandler EnterClicked;

        private async void CustomDisplayPrompt_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CustomDisplayPromptView(this, this.Id.ToString(), Title, Text, EnterClicked));
        }
    }
}