namespace Bilgi_SayarUI.Models
{
    public class LoginModel
    {
        private string? _returnUrl;
        public string? Name { get; set; }
        public string? Password { get; set; }

        public string ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                    return "/";
                else
                    return _returnUrl;
            }


            set { _returnUrl = value; }
        }


    }
}
