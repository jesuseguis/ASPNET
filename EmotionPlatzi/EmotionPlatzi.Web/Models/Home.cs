using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;


namespace EmotionPlatzi.Web.Models
{
    public class Home
    {
        public int Id { get; set; }
        public string WelcomeMessage { get; set; }
        public string FooterMessage { get; set; } = "Footer By Jesus Eguis";
  }
}