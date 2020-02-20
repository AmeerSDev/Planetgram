using Planetgram.Handler;
using Planetgram.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planetgram.ViewModel
{
    public class UserViewModel
    {
        private User igUser = new User();
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ICommandImp ScrapeCommand { get; set; }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public UserViewModel()
        {
                 ScrapeCommand = new ICommandImp(OnScrape,CanScrape);
            //   DisplayUser();
        }
        public User IGUser
        {
            get
            {
                return igUser;
            }

            set
            {
                igUser = value;
                ScrapeCommand.RaiseCanExecuteChanged();
            }
        }

        public void DisplayUser()
        {

            if (_users != null)
            {
                _users[0].UserName = IGUser.UserName;
                _users[0].UserFollowers = IGUser.UserFollowers;
                _users[0].UserFollowings = IGUser.UserFollowings;
            }
            else
                return;
        }
        private async void OnScrape()
        {
           igUser = await Scraper.ScrapeInstagram($"https://www.instagram.com//{igUser.UserName}/");
        }

        private bool CanScrape()
        {
            if (igUser != null)
                return true;
            return false;

        }
    }
}
