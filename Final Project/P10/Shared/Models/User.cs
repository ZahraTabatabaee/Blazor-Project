using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P10.Shared
{
    public class User
    {
        public int id{get; set;}
        [Required]
        public string User_name{get; set;}
        [Required]
        public string Password{get; set;}

        public override string ToString()
        {
            return $"{this.id}, {this.User_name}, {this.Password}";
        }
        public override int GetHashCode()
        {
            return this.id ;
        }
        public override bool Equals(object obj)
        {
            var other = obj as User ;
            if(obj is null)
                return false ;
            if(other.User_name == this.User_name & other.Password == this.Password )
                return true ;
            return false ;
        }
        public void SetValue( User other)
        {
            this.User_name = other.User_name ;
            this.Password = other.Password;
        }
    }
}