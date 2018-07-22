using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CriminalMindsQuotes.Pages
{
    public partial class PrivarcyPage : ContentPage
    {
        string _publisher = "Jaidee Software";

        public PrivarcyPage()
        {
            InitializeComponent();

            SetPrivacyText_General();
            SetPrivacyText_Collect();
            SetPrivacyText_Security();
            SetPrivacyText_Links();
        }

        private void SetPrivacyText_General()
        {
            string _privacyText_General = string.Empty;

            _privacyText_General = string.Format("This privacy policy sets out how “{0}” uses and protects any information that you give “{0}” when you use this application.", _publisher);
            _privacyText_General += System.Environment.NewLine + System.Environment.NewLine;
            _privacyText_General += string.Format("“{0}” is committed to ensuring that your privacy is protected. ", _publisher);
            _privacyText_General += "Should we ask you to provide certain information by which you can be identified when using this application, ";
            _privacyText_General += "then you can be assured that it will only be used in accordance with this privacy statement.";
            _privacyText_General += System.Environment.NewLine + System.Environment.NewLine;
            _privacyText_General += string.Format("“{0}” may change this policy from time to time by updating this page.", _publisher);
            _privacyText_General += "You should check this page from time to time to ensure that you are happy with any changes. This policy is effective from August 1., 2015";

            this.PrivacyText_General.Text = _privacyText_General;
        }
        private void SetPrivacyText_Collect()
        {
            string _privacyText_Collect = string.Empty;

            _privacyText_Collect = "We are not collect any private information is thie application.";

            this.PrivacyText_Collect.Text = _privacyText_Collect;
        }
        private void SetPrivacyText_Security()
        {
            string _privacyText_Security = string.Empty;

            _privacyText_Security = "We are committed to ensuring that your information is secure. ";
            _privacyText_Security += "In order to prevent unauthorised access or disclosure we have put in place suitable physical, ";
            _privacyText_Security += "electronic and managerial procedures to safeguard and secure the information we collect.";

            this.PrivacyText_Security.Text = _privacyText_Security;
        }
        private void SetPrivacyText_Links()
        {
            string _privacyText_Links = string.Empty;

            _privacyText_Links = "Our application may contain links to other applications or websites of interest. However, once you have used these links to leave our application, ";
            _privacyText_Links += "you should note that we do not have any control over that other application or website. Therefore, we cannot be responsible for the protection ";
            _privacyText_Links += "and privacy of any information which you provide whilst visiting such sites and such sites are not governed by this privacy statement.";
            _privacyText_Links += "You should exercise caution and look at the privacy statement applicable to the application in question.";

            this.PrivacyText_Links.Text = _privacyText_Links;
        }
    }
}
