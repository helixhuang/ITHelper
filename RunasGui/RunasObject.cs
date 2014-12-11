using System;
using System.Collections.Generic;
using System.Text;

namespace RunasGui
{
    public class RunasObject
    {
        public string Name { get; set; }
        public string ExeFile { get; set; }
        public string Args { get; set; }
        public string Domain { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string GetPassword() {
            return AESHelper.DecryptText(this.Password);
        }

        public void SetPassword(string value)
        {
            this.Password = AESHelper.EncryptText(value);
        }
    }
}
