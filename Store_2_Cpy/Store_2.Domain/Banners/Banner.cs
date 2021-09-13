using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Banners
{
    public class Banner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public Position Position { get; set; }
    }
    public enum Position
    {

        Slider=0,
       
        Line_1 =1,
        Line_2=2,
        Line_3=3,
        Line_4=4,
        Line_5=5,
    }
}
