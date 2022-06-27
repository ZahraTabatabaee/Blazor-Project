using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using P10.Shared;

namespace Models
{
    public static class Shopping{
        public static int sum = 0 ;
        public static kala k_p;
        public static User u ;
        public static Dictionary<kala,int> ShopList = new Dictionary<kala, int>();
        // public static List<kala> ShopList = new List<kala>();
    }
    
}