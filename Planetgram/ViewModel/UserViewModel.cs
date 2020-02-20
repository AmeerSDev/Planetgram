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
        private User igUser;
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ICommandImp ScrapeCommand { get; set; }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public UserViewModel()
        {
            igUser = new User();
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

        public void DisplayUser(User iu)
        {

            if (iu != null)
            {
                igUser.UserName = iu.UserName;
                igUser.UserFollowers = iu.UserFollowers;
                igUser.UserFollowings = iu.UserFollowings;
            }
            else
                return;
        }
        private async void OnScrape()
        {
            if (igUser != null)
            {
                User iu = await Scraper.ScrapeInstagram($"https://www.instagram.com/{igUser.UserName}/");
                DisplayUser(iu);
            }
            else
                return;
        }

        private bool CanScrape()
        {
            if (igUser != null)
                return true;
            return false;

        }
    }
}
