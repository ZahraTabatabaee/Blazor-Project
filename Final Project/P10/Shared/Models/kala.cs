using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P10.Shared
{
    public class kala
    {
        // public int Count = 0;
        [Required]
        public int id{get; set;}
        [Required]
        public string p_name{get; set;}
        [Required]
        public string p_category{get; set;}
        [Required]
        public string p_info{get; set;}
        [Required]
        public int p_price{get; set;}
        [Required]
        public string p_link{get; set;}
        [Required]
        public int p_count{get; set;}
        

        // public kala(int id ,string name, string category , string info ,int Count , int price, string link)
        // {
        //     id = id ;
        //     p_name = name ;
        //     p_category = category ;
        //     p_info = info ; 
        //     p_count = Count ;
        //     p_price = price ;
        //     p_link = link ;
        // }
        public override string ToString()
        {
            return $"{this.id}, {this.p_name}, {this.p_category}, {this.p_info}, {this.p_count}, {this.p_price}, {this.p_link}";
        }
        public override int GetHashCode()
        {
            return this.id ;
        }
        public override bool Equals(object obj)
        {
            var other = obj as kala ;
            if(obj is null)
                return false ;
            return this.id == other.id ;
        }
        public void SetValue( kala other)
        {
            this.p_name = other.p_name ;
            this.p_category = other.p_category;
            this.p_info = other.p_info ;
            this.p_count = other.p_count ;
            this.p_price = other.p_price;
            this.p_link = other.p_link;
        }
    }
}