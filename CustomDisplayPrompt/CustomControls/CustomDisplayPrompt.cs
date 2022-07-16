using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CustomDisplayPrompt.CustomControls
{
    public class CustomDisplayPrompt : Button
    {
        public CustomDisplayPrompt()
        {
            MessagingCenter.Subscribe<Page, string>(this, this.Id.ToString(), (p, value) =>
            {
                Text = value;
            });
            this.Clicked += CustomDisplayPrompt_Clicked;
        }

        private async void CustomDisplayPrompt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CustomDisplayPromptView(this, this.Id.ToString(), Title, Text, EnterClicked));
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(String), typeof(CustomDisplayPrompt), "Type a Value", BindingMode.TwoWay);
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public event EventHandler EnterClicked;
    }
}