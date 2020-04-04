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
        //TODO:Add Color Binding
       /*-1 Unused 00000000
          0 Poor ff9d9d9d
          1 Common ffffffff
          2 Uncommon ff1eff00
          3 Rare ff0070dd
          4 Epic ffa335ee
          5 Legendary ffff8000
          */
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
                igUser.UserAlias = iu.UserAlias;
                igUser.UserFollowers = iu.UserFollowers;
                igUser.UserFollowings = iu.UserFollowings;
                PlanetViewModel.planet.Color = igUser.UserFollowers;
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
