using System;
using System.Windows.Forms;

namespace ConsumingWebServicesClientGrpfic
{
    public partial class RegisterUser : Form
    {
        public string EmailText { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterUser()
        {
            InitializeComponent();
        }

        public void RegisterUserButtonClick(object sender, EventArgs e)
        {
            this.EmailText = emailTextbox.Text;
            this.Password = passwordTextbox.Text;
            this.ConfirmPassword = confirmPasswordTextbox.Text;
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void confirmPasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextbox.Text == confirmPasswordTextbox.Text && 
                !string.IsNullOrEmpty(emailTextbox.Text) && 
                !string.IsNullOrWhiteSpace(emailTextbox.Text))
            {
                registerButton.Enabled = true;
            }
        }
    }
}
