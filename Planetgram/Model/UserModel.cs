using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Planetgram.Model
{
    public class UserModel{ }
    public class User : INotifyPropertyChanged
    {
        private string userName;
        private string userPassword;
        private int userFollowers;
        private byte[] userImage;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                if (userName != value)
                {
                    userName = value;
                    RaisePropertyChanged("UserName");
                }
            }
        }

        public string UserPassword
        {
            get { return userPassword; }

            set
            {
                if (userPassword != value)
                {
                    userPassword = value;
                    RaisePropertyChanged("UserPassword");
                }
            }
        }
        public int UserFollowers
        {
            get { return userFollowers; }

            set
            {
                if (userFollowers != value)
                {
                    userFollowers = value;
                    RaisePropertyChanged("UserFollowers");
                }
            }
        }
        public byte[] UserImage
        {
            get { return userImage; }

            set
            {
                if (userImage != value)
                {
                    userImage = value;
                    RaisePropertyChanged("UserImage");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

}
