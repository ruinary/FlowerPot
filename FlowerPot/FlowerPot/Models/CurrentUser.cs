using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerPot.Models
{
    public class CurrentUser
    {
        public int id_user { get; set; }
        public bool is_admin { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Midle_Name { get; set; }
        public string email { get; set; }
        public string phone_num { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string user_img_path { get; set; }
    }
}
