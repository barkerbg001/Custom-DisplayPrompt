using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CustomDisplayPrompt.CustomControls
{
    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            GestureRecognizers.Add(TapGestureRecognizer = new TapGestureRecognizer());
        }

        private readonly object _tappedEventPadlock = new object();
        /// <summary>
        /// Event invoked when this button's TapGestureRecogniser is tapped
        /// </summary>
        public event EventHandler Tapped
        {
            add
            {
                lock (_tappedEventPadlock)
                {
                    TapGestureRecognizer.Tapped += value;
                }
            }
            remove
            {
                lock (_tappedEventPadlock)
                {
                    TapGestureRecognizer.Tapped -= value;
                }
            }
        }

        /// <summary>
        /// Handles tap events on this button, by default will invoke TapGestureRecognizer_Tapped, and call the Tapped ICommand
        /// </summary>
        protected TapGestureRecognizer TapGestureRecognizer
        {
            get;
            set;
        }
    }
}