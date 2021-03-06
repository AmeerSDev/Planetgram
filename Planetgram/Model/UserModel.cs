﻿using System;
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
        private string userAlias;
        private int userFollowers;
        private int userFollowings;
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
        public string UserAlias
        {
            get
            {
                return userAlias;
            }

            set
            {
                if (userAlias != value)
                {
                    userAlias = value;
                    RaisePropertyChanged("UserAlias");
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
        public int UserFollowings
        {
            get { return userFollowings; }

            set
            {
                if (userFollowings != value)
                {
                    userFollowings = value;
                    RaisePropertyChanged("UserFollowings");
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
