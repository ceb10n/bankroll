using bankroll.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bankroll
{
    public class SessionProfile
    {

        private enum Key : short
        {
            Player,
        }

        public static Player Player
        {
            get
            {
                if (HttpContext.Current.Session[Key.Player.ToString()] == null)
                    return null;

                return HttpContext.Current.Session[Key.Player.ToString()] as Player;
            }
            set
            {
                HttpContext.Current.Session[Key.Player.ToString()] = value;
            }
        }

        public static bool IsLogged
        {
            get
            {
                return Player != null;
            }
        }
    }
}